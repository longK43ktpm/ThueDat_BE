﻿using Abp.Application.Services.Dto;

namespace ThueDat.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

