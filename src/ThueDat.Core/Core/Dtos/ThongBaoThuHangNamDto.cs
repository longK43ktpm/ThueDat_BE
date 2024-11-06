using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using ThueDat.Core.Entities;

namespace ThueDat.Core.Dtos
{
    [AutoMap(typeof(ThongBaoThuHangNam))]
    public class ThongBaoThuHangNamDto : EntityDto<int>
    {
        public string SoThongBao { get; set; }

        public DateOnly? ThoiGianGhiThuTu { get; set; }

        public DateOnly? ThoiGianGhiThuDen { get; set; }

        public int? SoThangGhiThu { get; set; }

        public string MaSoThue { get; set; }

        public string SoMienGiam { get; set; }
    }
}
