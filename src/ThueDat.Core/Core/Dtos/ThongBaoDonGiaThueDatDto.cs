using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ThueDat.Core.Entities;

namespace ThueDat.Core.Dtos
{
    [AutoMap(typeof(ThongBaoDonGiaThueDat))]
    public class ThongBaoDonGiaThueDatDto : EntityDto<int>
    {
        public string SoThongBao { get; set; }

        public DateOnly? GhiThuTu { get; set; }

        public DateOnly? GhiThuDen { get; set; }

        public DateOnly? OnDinhDGTu { get; set; }

        public DateOnly? OnDinhDGDen { get; set; }

        public float? DienTich { get; set; }

        public decimal? DonGia { get; set; }

        public decimal? TienGhiThu { get; set; }

        public string ThuaDatSo { get; set; }

        public string SoQuyetDinh { get; set; }
    }
}
