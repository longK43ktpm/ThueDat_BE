using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.ObjectMapping;
using Aspose.Cells;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThueDat.Core.Dtos;
using ThueDat.Core.Entities;

namespace ThueDat.Core.DomainServices
{
    public class NguoiNopThueManager : IDomainService
    {
        private readonly IRepository<NguoiNopThue> _NguoiNopThueRepository;
        private readonly IObjectMapper ObjectMapper;

        public NguoiNopThueManager(IRepository<NguoiNopThue> nguoiNopThueRepository, IObjectMapper objectMapper)
        {
            _NguoiNopThueRepository = nguoiNopThueRepository;
            ObjectMapper = objectMapper;
        }

        public IQueryable<NguoiNopThueDto> GetAllNguoiNopThue()
        {
            var query = from ntt in _NguoiNopThueRepository.GetAll()
                        select new NguoiNopThueDto
                        {
                            Id = ntt.Id,
                            MaSoThue = ntt.MaSoThue,
                            Ten = ntt.Ten,
                            DiaChi = ntt.DiaChi,
                            SoDienThoai = ntt.SoDienThoai,
                            Email = ntt.Email,
                            LoaiHinh = ntt.LoaiHinh,
                            LastModifierUserId = ntt.LastModifierUserId,
                            LastModificationTime = ntt.LastModificationTime
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

                List<NguoiNopThueDto> dsNNT = new List<NguoiNopThueDto>();

                for (int i = 7; i < sheetSource.Cells.MaxDataRow + 1; i++)
                {
                    var maSoThue = cellsSource["B" + i].Value;
                    var tenDoiTuong = cellsSource["C" + i].Value;
                    if (maSoThue != null && tenDoiTuong != null)
                    {
                        NguoiNopThueDto nnt = new NguoiNopThueDto
                                            {
                                                MaSoThue = maSoThue.ToString().Trim(),
                                                Ten = tenDoiTuong.ToString().Trim(),
                                            };
                        dsNNT.Add(nnt);
                    }
                }

                ExportDuplicateDataToExcel(dsNNT);

                dsNNT = RemoveDuplicateData(dsNNT);

                ImportNewDataIntoDatabase(dsNNT);
            }
        }

        private List<NguoiNopThueDto> GetDuplicateData(List<NguoiNopThueDto> DsNguoiNopThue)
        {
            var duplicates = DsNguoiNopThue.GroupBy(x => x.MaSoThue)
                                .Where(g => g.Count() > 1)
                                .SelectMany(g => g)
                                .ToList();
            return duplicates;
        }

        private void ExportDuplicateDataToExcel(List<NguoiNopThueDto> nguoiNopThueDtos)
        {
            var duplicates = GetDuplicateData(nguoiNopThueDtos);

            Workbook workbookDest = new Workbook();
            Worksheet sheetDest = workbookDest.Worksheets[0];
            Cells cellsDest = sheetDest.Cells;

            cellsDest["A1"].Value = "Mã Số Thuế";
            cellsDest["B1"].Value = "Tên Đối Tượng";

            for (int i = 0; i < duplicates.Count; i++)
            {
                sheetDest.Cells.InsertRow(i + 2);
                cellsDest["A" + (i + 2)].Value = duplicates[i].MaSoThue;
                cellsDest["B" + (i + 2)].Value = duplicates[i].Ten;
            }
            workbookDest.Save(@"D:\D-L\dest.xlsx", SaveFormat.Xlsx);
        }

        private List<NguoiNopThueDto> RemoveDuplicateData(List<NguoiNopThueDto> nguoiNopThueDtos)
        {
            var duplicates = GetDuplicateData(nguoiNopThueDtos);
            var result = nguoiNopThueDtos.Except(duplicates).ToList();
            return result;
        }

        private void ImportNewDataIntoDatabase(List<NguoiNopThueDto> nguoiNopThueDtos)
        {
            List<string> allOldMst = GetAllNguoiNopThue().Select(x => x.MaSoThue).ToList();
            List<string> allImportMst = nguoiNopThueDtos.Select(x => x.MaSoThue).ToList();

            var newMst = allImportMst.Except(allOldMst).ToList();

            var newDatas = nguoiNopThueDtos.Where(x => newMst.Contains(x.MaSoThue));

            foreach (var item in newDatas)
            {
                NguoiNopThue data = ObjectMapper.Map<NguoiNopThue>(item);
                _NguoiNopThueRepository.Insert(data);
            }
        }
    }
}
