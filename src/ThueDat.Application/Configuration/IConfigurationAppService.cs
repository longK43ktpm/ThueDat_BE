using System.Threading.Tasks;
using ThueDat.Configuration.Dto;

namespace ThueDat.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
