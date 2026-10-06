using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Playwright;
using AutoTestsForApplications.ForUI.Fixtures;
using AutoTestsForApplications.ForUI.Pages;
using AutoTestsForApplications.ForUI.Models;

namespace AutoTestsForApplications.Tests.UI_Tests
{
    public class DemoQAFormTests : BaseTest
    {
        [Test]
        public async Task FillForm_ShowsThankYouMessage()
        {
            var homePage = new DemoQAHomePage(Page);
            var formsPage = new DemoQAFormsPage(Page);
            var formPage = new DemoQAFormFillPage(Page);
            var finalPage = new DemoQAFinalPage(Page);

            var data = new FormDataBuilder()
                .WithFirstName("Ilya")
                .WithLastName("Test")
                .WithEmail("ilya@test.com")
                .WithGender(Gender.Male)
                .WithMobile("1234567890")
                .WithHobbies(Hobbies.Reading)
                .WithDays("15")
                .WithMonth("May")
                .WithYear("1995")
                .WithSubject("Maths")
                .WithCurrentAddress("Street 1")
                .WithState("NCR")
                .WithCity("Delhi")
                .Build();

            await homePage.OpenAsync();
            await homePage.GoForms();
            await formsPage.GoToPracticeForms();

            await formPage.FillFormAsync(data);
            await formPage.Submit();

            await Assertions.Expect(Page.GetByText("Thanks for submitting the form")).ToBeVisibleAsync();

            await Assertions.Expect(finalPage.ResultTitle).ToBeVisibleAsync();

            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync($"{data.FirstName} {data.LastName}");
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Email);
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Mobile);

            await finalPage.CloseButtonAsync();
        }
    }
}