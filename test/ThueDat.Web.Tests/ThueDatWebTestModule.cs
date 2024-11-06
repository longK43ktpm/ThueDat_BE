using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ThueDat.EntityFrameworkCore;
using ThueDat.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ThueDat.Web.Tests
{
    [DependsOn(
        typeof(ThueDatWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ThueDatWebTestModule : AbpModule
    {
        public ThueDatWebTestModule(ThueDatEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ThueDatWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ThueDatWebMvcModule).Assembly);
        }
    }
}