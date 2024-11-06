using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ThueDat.Configuration;

namespace ThueDat.Web.Host.Startup
{
    [DependsOn(
       typeof(ThueDatWebCoreModule))]
    public class ThueDatWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ThueDatWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ThueDatWebHostModule).GetAssembly());
        }
    }
}
