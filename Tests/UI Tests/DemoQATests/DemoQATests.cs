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

                (await finalPage.GetResultValueAsync("Student Name")).Should().Be($"{data.FirstName} {data.LastName}");
                (await finalPage.GetResultValueAsync("Student Email")).Should().Be(data.Email);
                (await finalPage.GetResultValueAsync("Gender")).Should().Be(data.Gender.ToString());
                (await finalPage.GetResultValueAsync("Mobile")).Should().Be(data.Mobile);
                (await finalPage.GetResultValueAsync("Date of Birth")).Should().Be($"{data.Days} {data.Month},{data.Year}");
                (await finalPage.GetResultValueAsync("Subjects")).Should().Be(data.Subject);
                (await finalPage.GetResultValueAsync("Hobbies")).Should().Be(data.Hobby.ToString());
                (await finalPage.GetResultValueAsync("Address")).Should().Be(data.CurrentAddress);
                (await finalPage.GetResultValueAsync("State and City")).Should().Be($"{data.State} {data.City}");
            }

            await finalPage.CloseButtonAsync();
        }
    }
}
