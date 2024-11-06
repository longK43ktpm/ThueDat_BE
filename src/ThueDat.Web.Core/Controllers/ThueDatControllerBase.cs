using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ThueDat.Controllers
{
    public abstract class ThueDatControllerBase: AbpController
    {
        protected ThueDatControllerBase()
        {
            LocalizationSourceName = ThueDatConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
