using AutoTestsForApplications.ForUI.Fixtures;
using AutoTestsForApplications.ForUI.Pages;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
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


        [TestCaseSource(nameof(ValidUsers))]
        public async Task UsersLoginTestAdvanced(string username)
        {
            await LoginAndCheck(username);
        }

        private static IEnumerable<string> ValidUsers()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "users.json");
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<string>>(json);
        }

        private async Task LoginAndCheck(string username)
        {
            var loginPage = new LoginPage(Page);
            var productsPage = new ProductsPage(Page);

            await loginPage.OpenAsync();
            await loginPage.LoginAsync(username, "secret_sauce");

            (await productsPage.IsProductsTitleVisibleAsync()).Should().BeTrue();
        }
    }
}