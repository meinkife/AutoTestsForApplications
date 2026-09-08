using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using AutoTestsForApplications.ForUI.Fixtures;

namespace AutoTestsForApplications.Tests.UI_Tests
{
    public class SauceDemoTests : BaseTest
    {
        [Test]
        public async Task SuccessLogin()
        {
            await Page.GotoAsync("https://www.saucedemo.com/");
            await Page.GetByPlaceholder("Username").FillAsync("standard_user");
            await Page.GetByPlaceholder("Password").FillAsync("secret_sauce");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
            await Assertions.Expect(Page.GetByText("Products")).ToBeVisibleAsync();
        }
    }
}