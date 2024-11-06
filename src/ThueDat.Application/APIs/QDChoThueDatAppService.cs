using Abp.Application.Services;
using Abp.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThueDat.Authorization;
using ThueDat.Core.DomainServices;
using ThueDat.Core.Dtos;
using ThueDat.Core.Extensions;
using ThueDat.Core.Paging;

namespace ThueDat.APIs
{
    [Authorize]
    public class QDChoThueDatAppService : ApplicationService
    {
        private readonly QDChoThueDatManager _QDChoThueDatManager;

        public QDChoThueDatAppService(QDChoThueDatManager qDChoThueDatManager)
        {
            _QDChoThueDatManager = qDChoThueDatManager;
        }

        [HttpPost]
        [AbpAuthorize(PermissionNames.Pages_QuyetDinhChoThueDat)]
        public async Task<GridResult<QuyetDinhChoThueDatDto>> GetAllPaging(GridParam param)
        {
            var query = _QDChoThueDatManager.GetAllQDChoThueDat();
            return await query.GetGridResult(param);
        }

        [HttpPost]
        [AbpAuthorize(PermissionNames.Pages_QuyetDinhChoThueDat)]
        [ApiExplorerSettings(IgnoreApi = true)]     //ignore this API when generate Swagger
        public async Task<string> ImportFromFile([FromForm] IFormFile file)
        {
            _QDChoThueDatManager.ImportFromExcelFile(file);
            return "import ok";
        }
    }
}
