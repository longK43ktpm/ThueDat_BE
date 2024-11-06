using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ThueDat.Configuration.Dto;

namespace ThueDat.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ThueDatAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
