using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThueDat.Core.Entities;

namespace ThueDat.Core.Dtos
{
    [AutoMap(typeof(NguoiNopThue))]
    public class NguoiNopThueDto : EntityDto<int>
    {
        public string MaSoThue { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public CacLoaiHinh? LoaiHinh { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; } 
    }
}
