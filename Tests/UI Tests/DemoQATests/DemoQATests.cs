using AutoTestsForApplications.ForUI.Fixtures;
using AutoTestsForApplications.ForUI.Models;
using AutoTestsForApplications.ForUI.Pages;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

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

            var title = await finalPage.GetResultTitleAsync();

            using (new AssertionScope())
            {
                title.Should().Be("Thanks for submitting the form");

            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync($"{data.FirstName} {data.LastName}");
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Email);
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Mobile);
<<<<<<<<< Temporary merge branch 1
=========
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Gender.ToString());
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Hobby.ToString());
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Days);
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Month);
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Year);
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.Subject);
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.CurrentAddress);
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.State);
            await Assertions.Expect(finalPage.ResultTable).ToContainTextAsync(data.City);
            
>>>>>>>>> Temporary merge branch 2

            await finalPage.CloseButtonAsync();
        }
    }
}
