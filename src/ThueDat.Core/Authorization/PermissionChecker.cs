using Abp.Authorization;
using ThueDat.Authorization.Roles;
using ThueDat.Authorization.Users;

namespace ThueDat.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
