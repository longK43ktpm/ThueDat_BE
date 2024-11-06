using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using ThueDat.Core.Entities;

namespace ThueDat.Core.Dtos
{
    [AutoMap(typeof(QuyetDinhChoThueDat))]
    public class QuyetDinhChoThueDatDto : EntityDto<int>
    {
        public string SoQuyetDinh { get; set; }
        public DateOnly? Ngay { get; set; }
        public float? DienTich { get; set; }
        public string DiaChi { get; set; }
        public DateOnly? NgayBatDauThue { get; set; }
        public DateOnly? NgayHetHanThue { get; set; }
        public CacHinhThucTraTien? HinhThucTraTien { get; set; }
        public string MaSoThue { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
