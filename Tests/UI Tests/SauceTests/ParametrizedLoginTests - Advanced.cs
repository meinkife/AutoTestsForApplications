using AutoTestsForApplications.ForUI.Fixtures;
using AutoTestsForApplications.ForUI.Pages;
using AutoTestsForApplications.ForUI.TestData;
using FluentAssertions;
using NUnit.Framework;       
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoTestsForApplications.Tests.UI_Tests
{
    public class LoginTestsAdvanced : BaseTest
    {
        [TestCaseSource(typeof(LoginTestData), nameof(LoginTestData.UsersFromJson))]
        public async Task UsersLoginTestAdvanced(string username)
        {
            var loginPage = new LoginPage(Page);
            var productsPage = new ProductsPage(Page);

            await loginPage.OpenAsync();
            await loginPage.LoginAsync(username, "secret_sauce");

            (await productsPage.IsProductsTitleVisibleAsync()).Should().BeTrue();
        }
    }
}