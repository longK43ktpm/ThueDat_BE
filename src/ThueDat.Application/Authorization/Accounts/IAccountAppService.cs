using System.Threading.Tasks;
using Abp.Application.Services;
using ThueDat.Authorization.Accounts.Dto;

namespace ThueDat.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
