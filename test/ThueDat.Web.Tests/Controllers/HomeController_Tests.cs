using System.Threading.Tasks;
using ThueDat.Models.TokenAuth;
using ThueDat.Web.Controllers;
using Shouldly;
using Xunit;

namespace ThueDat.Web.Tests.Controllers
{
    public class HomeController_Tests: ThueDatWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}