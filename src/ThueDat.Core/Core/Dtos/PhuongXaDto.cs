using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using ThueDat.Core.Entities;

namespace ThueDat.Core.Dtos
{
    [AutoMap(typeof(PhuongXa))]
    public class PhuongXaDto : EntityDto<int>
    {
        public int MaPX { get; set; }

        public string Ten { get; set; }

        public int? MaQH { get; set; }
    }
}
