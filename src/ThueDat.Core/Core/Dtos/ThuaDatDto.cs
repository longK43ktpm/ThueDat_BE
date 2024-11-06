using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThueDat.Core.Entities;

namespace ThueDat.Core.Dtos
{
    [AutoMap(typeof(ThuaDat))]
    public class ThuaDatDto : EntityDto<int>
    {
        public string ThuaDatSo { get; set; }

        public string ToBanDoSo { get; set; }

        public string DiaChi { get; set; }

        public string SoNha { get; set; }

        public string ToaNha { get; set; }

        public string NgoHem { get; set; }

        public string DuongPho { get; set; }

        public string ThonXomAp { get; set; }

        public string PhuongXa { get; set; }

        public string QuanHuyen { get; set; }

        public string TinhThanhPho { get; set; }

        public string DoanDuong { get; set; }

        public string MucDichSuDung { get; set; }

        public string NguonGoc { get; set; }

        public int? ThoiHanThueNam { get; set; }

        public string ViTriThuaDat { get; set; }

        public float? DienTichDatThueM2 { get; set; }

        public float? DienTichNopTien { get; set; }

        public float? DienTichKhongNopTien { get; set; }

        public string ToaDo { get; set; }

        public string SoQuyetDinh { get; set; }
    }
}
