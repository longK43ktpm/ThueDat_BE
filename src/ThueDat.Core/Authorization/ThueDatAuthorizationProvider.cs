using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ThueDat.Authorization
{
    public class ThueDatAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            foreach (var permission in SystemPermission.ListPermissions)
            {
                context.CreatePermission(permission.Name, L(permission.DisplayName));
            }
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ThueDatConsts.LocalizationSourceName);
        }
    }
}
