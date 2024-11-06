using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using ThueDat.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThueDat.Authorization;
using ThueDat.Core.Entities;
using ThueDat.Core.Paging;
using Microsoft.AspNetCore.Authorization;
using ThueDat.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Aspose.Cells;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ThueDat.Core.DomainServices;

namespace ThueDat.APIs
{
    [Authorize]
    public class NguoiNopThueAppService : ApplicationService
    {
        private readonly NguoiNopThueManager _NguoiNopThueManager;

        public NguoiNopThueAppService(NguoiNopThueManager nguoiNopThueManager)
        {
            _NguoiNopThueManager = nguoiNopThueManager;
        }

        [HttpPost]
        [AbpAuthorize(PermissionNames.Pages_NguoiNopThue)]
        public async Task<GridResult<NguoiNopThueDto>> GetAllPaging(GridParam param)
        {
            var query = _NguoiNopThueManager.GetAllNguoiNopThue();
            return await query.GetGridResult(param);
        }

        [HttpPost]
        [AbpAuthorize(PermissionNames.Pages_NguoiNopThue)]
        [ApiExplorerSettings(IgnoreApi = true)]     //ignore this API when generate Swagger
        public async Task<string> ImportFromFile([FromForm] IFormFile file)
        {
            _NguoiNopThueManager.ImportFromExcelFile(file);
            return "import ok";
        }
    }
}
