using System.Threading.Tasks;
using Abp.Application.Services;
using ThueDat.Sessions.Dto;

namespace ThueDat.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
