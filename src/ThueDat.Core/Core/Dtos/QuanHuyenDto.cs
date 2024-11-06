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
    [AutoMap(typeof(QuanHuyen))]
    public class QuanHuyenDto : EntityDto<int>
    {
        public int MaQH { get; set; }
        public string Ten { get; set; }
    }
}
