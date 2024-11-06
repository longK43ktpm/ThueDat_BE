using Abp.Application.Services;
using ThueDat.MultiTenancy.Dto;

namespace ThueDat.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

