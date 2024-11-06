using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ThueDat.Authorization;

namespace ThueDat
{
    [DependsOn(
        typeof(ThueDatCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ThueDatApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ThueDatAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ThueDatApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
