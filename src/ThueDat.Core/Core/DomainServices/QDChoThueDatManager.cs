using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.ObjectMapping;
using Aspose.Cells;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThueDat.Core.Dtos;
using ThueDat.Core.Entities;

namespace ThueDat.Core.DomainServices
{
    public class QDChoThueDatManager : IDomainService
    {
        private readonly IRepository<QuyetDinhChoThueDat> _QDChoThueDatRepository;
        private readonly IObjectMapper ObjectMapper;
        private readonly NguoiNopThueManager _NguoiNopThueManager;

        public QDChoThueDatManager(
            IRepository<QuyetDinhChoThueDat> nguoiNopThueRepository,
            IObjectMapper objectMapper,
            NguoiNopThueManager nguoiNopThueManager)
        {
            _QDChoThueDatRepository = nguoiNopThueRepository;
            ObjectMapper = objectMapper;
            _NguoiNopThueManager = nguoiNopThueManager;
        }

        public IQueryable<QuyetDinhChoThueDatDto> GetAllQDChoThueDat()
        {
            var query = from quyetDinh in _QDChoThueDatRepository.GetAll()
                        select new QuyetDinhChoThueDatDto
                        {
                            Id = quyetDinh.Id,
                            SoQuyetDinh = quyetDinh.SoQuyetDinh,
                            DienTich = quyetDinh.DienTich,
                            DiaChi = quyetDinh.DiaChi,
                            Ngay = quyetDinh.Ngay,
                            NgayBatDauThue = quyetDinh.NgayBatDauThue,
                            NgayHetHanThue = quyetDinh.NgayHetHanThue,
                            HinhThucTraTien = quyetDinh.HinhThucTraTien,
                            MaSoThue = quyetDinh.MaSoThue,
                            LastModifierUserId = quyetDinh.LastModifierUserId,
                            LastModificationTime = quyetDinh.LastModificationTime
                        };
            return query;
        }

        public void ImportFromExcelFile(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                Workbook workbookSource = new Workbook(stream);
                Worksheet sheetSource = workbookSource.Worksheets[0];
                Cells cellsSource = sheetSource.Cells;

                List<QuyetDinhChoThueDatDto> quyetDinhDtos = new List<QuyetDinhChoThueDatDto>();

                for (int i = 4; i < sheetSource.Cells.MaxDataRow + 1; i++)
                {
                    var soQuyetDinh = cellsSource["D" + i].Value;
                    var ngay = cellsSource["E" + i].Value;
                    var dienTich = cellsSource["O" + i].Value;
                    var diaChi = cellsSource["L" + i].Value;
                    var thueTu = cellsSource["G" + i].Value;
                    var thueDen = cellsSource["H" + i].Value;
                    var hinhThucTra = cellsSource["I" + i].Value;
                    var maSoThue = cellsSource["B" + i].Value;

                    if (soQuyetDinh != null)
                    {
                        QuyetDinhChoThueDatDto quyetDinhDto = new QuyetDinhChoThueDatDto
                        {
                            SoQuyetDinh = NormalizeString(soQuyetDinh.ToString().Trim()),
                            Ngay = ngay != null
                                ? DateTime.TryParse(thueDen.ToString().Trim(), out DateTime dateTimeNgay)
                                    ? DateOnly.FromDateTime(dateTimeNgay)
                                    : null
                                : null,
                            DienTich = dienTich != null
                                ? float.Parse(dienTich.ToString().Trim().Replace(",", ""))
                                : null,
                            DiaChi = diaChi?.ToString().Trim(),
                            NgayBatDauThue = thueTu != null
                                ? DateTime.TryParse(thueTu.ToString().Trim(), out DateTime dateTimetThueTu)
                                    ? DateOnly.FromDateTime(dateTimetThueTu)
                                    : null
                                : null,
                            NgayHetHanThue = thueDen != null
                                ? DateTime.TryParse(thueDen.ToString().Trim(), out DateTime dateTimeThueDen)
                                    ? DateOnly.FromDateTime(dateTimeThueDen)
                                    : null
                                : null,
                            HinhThucTraTien = hinhThucTra != null
                                ? hinhThucTra.ToString().Trim() == "Trả tiền hàng năm"
                                    ? CacHinhThucTraTien.TraTienHangNam
                                    : CacHinhThucTraTien.TraTienMotLan
                                : null,
                            MaSoThue = maSoThue?.ToString().Trim(),
                        };

                        quyetDinhDtos.Add(quyetDinhDto);
                    }
                }

                ExportInvalidDataToExcel(quyetDinhDtos);

                quyetDinhDtos = RemoveInvalidData(quyetDinhDtos);

                ImportNewDataIntoDatabase(quyetDinhDtos);
            }
        }

        private List<QuyetDinhChoThueDatDto> GetDuplicateData(List<QuyetDinhChoThueDatDto> quyetDinhDtos)
        {
            var duplicatesGroup = quyetDinhDtos.GroupBy(x => x.SoQuyetDinh)
                                .Where(g => g.Count() > 1);

            List<QuyetDinhChoThueDatDto> TongCongTyCoChiNhanh = new List<QuyetDinhChoThueDatDto>();

            foreach (var item in duplicatesGroup)
            {
                var minLengthGroup = item.GroupBy(x => x.MaSoThue.Length)
                    .OrderBy(g => g.Key)
                    .FirstOrDefault();

                var otherLengthGroup = item.GroupBy(x => x.MaSoThue.Length)
                    .OrderBy(g => g.Key)
                    .LastOrDefault();

                if (minLengthGroup.Count() == 1 &&
                    otherLengthGroup.FirstOrDefault().MaSoThue.Contains(minLengthGroup.FirstOrDefault().MaSoThue))
                {
                    TongCongTyCoChiNhanh.Add(minLengthGroup.FirstOrDefault());
                }
            }

            var duplicates = duplicatesGroup
                .SelectMany(x => x)
                .Except(TongCongTyCoChiNhanh)
                .ToList();

            return duplicates;
        }

        private List<QuyetDinhChoThueDatDto> GetInvalidMaSoThue(List<QuyetDinhChoThueDatDto> quyetDinhDtos)
        {
            var allMaSoThue = _NguoiNopThueManager.GetAllNguoiNopThue()
                .Select(x => x.MaSoThue)
                .ToList();
            var invalidMaSoThues = quyetDinhDtos.Where(x => !allMaSoThue.Contains(x.MaSoThue));
            return invalidMaSoThues.ToList();
        }

        private void ExportInvalidDataToExcel(List<QuyetDinhChoThueDatDto> nguoiNopThueDtos)
        {
            Workbook workbookDest = new Workbook();

            //Export duplicate SoQuyetDinh data to sheet 1
            Worksheet sheetDuplicate = workbookDest.Worksheets[0];
            sheetDuplicate.Name = "Số QĐ trùng lặp";
            var duplicates = GetDuplicateData(nguoiNopThueDtos);

            ExportDataToSheet(sheetDuplicate, duplicates);

            //Export invalid MaSoThue data to sheet 2
            workbookDest.Worksheets.Add();
            Worksheet sheetInvalidMST = workbookDest.Worksheets[1];
            sheetInvalidMST.Name = "Sai Mã Số Thuế";
            var invalidMSTs = GetInvalidMaSoThue(nguoiNopThueDtos);

            ExportDataToSheet(sheetInvalidMST, invalidMSTs);

            workbookDest.Save(@"D:\D-L\dest2.xlsx", SaveFormat.Xlsx);
        }

        private void ExportDataToSheet(Worksheet sheet, List<QuyetDinhChoThueDatDto> quyetDinhDtos)
        {
            Cells cells = sheet.Cells;

            cells["A1"].Value = "Số Quyết Định";
            cells["B1"].Value = "Mã Số Thuế";
            cells["C1"].Value = "Ngày Quyết Định";
            cells["D1"].Value = "Diện Tích";
            cells["E1"].Value = "Địa Chỉ";
            cells["F1"].Value = "Thuê Từ Ngày";
            cells["G1"].Value = "Thuê Đến Ngày";
            cells["H1"].Value = "Hình Thức Trả Tiền";

            for (int i = 0; i < quyetDinhDtos.Count; i++)
            {
                int rowIndex = i + 2;
                sheet.Cells.InsertRow(rowIndex);

                cells["A" + rowIndex].Value = quyetDinhDtos[i].SoQuyetDinh;
                cells["B" + rowIndex].Value = quyetDinhDtos[i].MaSoThue;
                cells["C" + rowIndex].Value = quyetDinhDtos[i].Ngay.ToString();
                cells["D" + rowIndex].Value = quyetDinhDtos[i].DienTich;
                cells["E" + rowIndex].Value = quyetDinhDtos[i].DiaChi;
                cells["F" + rowIndex].Value = quyetDinhDtos[i].NgayBatDauThue.ToString();
                cells["G" + rowIndex].Value = quyetDinhDtos[i].NgayHetHanThue.ToString();
                cells["H" + rowIndex].Value = quyetDinhDtos[i].HinhThucTraTien;
            }
        }

        private List<QuyetDinhChoThueDatDto> RemoveInvalidData(List<QuyetDinhChoThueDatDto> quyetDinhDtos)
        {
            var duplicates = GetDuplicateData(quyetDinhDtos);
            var result = quyetDinhDtos.Except(duplicates).ToList();

            var invalidMSTs = GetInvalidMaSoThue(result);
            var final = result.Except(invalidMSTs).ToList();

            return final;
        }

        private void ImportNewDataIntoDatabase(List<QuyetDinhChoThueDatDto> quyetDinhDtos)
        {
            List<string> allOldSQD = GetAllQDChoThueDat().Select(x => x.SoQuyetDinh).ToList();
            List<string> allImportSQD = quyetDinhDtos.Select(x => x.SoQuyetDinh).ToList();

            var newSQD = allImportSQD.Except(allOldSQD).ToList();

            var newDatas = quyetDinhDtos.Where(x => newSQD.Contains(x.SoQuyetDinh)).ToList();

            foreach (var item in newDatas)
            {
                QuyetDinhChoThueDat data = ObjectMapper.Map<QuyetDinhChoThueDat>(item);
                _QDChoThueDatRepository.Insert(data);
            }
        }

        public string NormalizeString(string input)
        {
            //they have different unicode
            string result1 = input.Replace("Ð", "Đ");
            string result2 = result1.Replace("Ð", "Đ");
            return result2;
        }
    }
}
