using AutoTestsForApplications.ForUI.Fixtures;
using AutoTestsForApplications.ForUI.Pages;
using FluentAssertions;
using NUnit.Framework;     
using System.Threading.Tasks;

namespace AutoTestsForApplications.Tests.UI_Tests
{
    public class LoginTests : BaseTest
    {
        [TestCase("standard_user")]
        [TestCase("problem_user")]
        [TestCase("performance_glitch_user")]
        [TestCase("error_user")]
        [TestCase("visual_user")]
        public async Task UsersLoginTestBase(string username)
        {
            var loginPage = new LoginPage(Page);
            var productsPage = new ProductsPage(Page);

            await loginPage.OpenAsync();
            await loginPage.LoginAsync(username, "secret_sauce");

            (await productsPage.IsProductsTitleVisibleAsync()).Should().BeTrue();
        }

    }
}