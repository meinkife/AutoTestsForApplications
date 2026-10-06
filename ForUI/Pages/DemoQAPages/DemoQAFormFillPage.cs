using AutoTestsForApplications.ForUI.Models;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AutoTestsForApplications.ForUI.Pages
{
    public enum Gender
    {Male,Female, Other}

    public enum Hobbies
    {Sports = 1, Reading = 2, Music = 3}
    public class DemoQAFormFillPage
    {
        private readonly IPage Page;

        private ILocator PracticeText => Page.GetByText("Practice form");
        private ILocator FirstNameInput => Page.GetByPlaceholder("First Name");
        private ILocator LastNameInput => Page.GetByPlaceholder("Last Name");
        private ILocator EmailInput => Page.GetByPlaceholder("name@example.com");
        private ILocator GenderRadio(Gender gender) => Page.Locator($"//input[@value='{gender}']");
        private ILocator HobbieCheck(Hobbies hobby) => Page.Locator($"//input[@value='{(int)hobby}']");
        private ILocator MobileNumberInput => Page.GetByPlaceholder("Mobile Number");
        private ILocator DateOfBirthInput => Page.Locator("#dateOfBirthInput");
        private ILocator MonthsSelector => Page.Locator(".react-datepicker__month-select");
        private ILocator DaysOfMonth => Page.Locator(".react-datepicker__day:not(.react-datepicker__day--outside-month)");
        private ILocator YearSelector => Page.Locator(".react-datepicker__year-select");
        private ILocator SubjectInput => Page.Locator("#subjectsInput");
        private ILocator CurrentAddressInput => Page.GetByPlaceholder("Current Address");
        private ILocator SelectStateInput => Page.Locator("#state");
        private ILocator SelectCityInput => Page.Locator("#city");

        private ILocator SubmitButton => Page.GetByRole(AriaRole.Button, new() { Name = "Submit" });

        public DemoQAFormFillPage(IPage page)
        {

            Page = page;

        }
       
        public async Task FillPersonalDataAsync(string firstName, string lastName, string email, string mobile)
        {
            await FirstNameInput.FillAsync(firstName);
            await LastNameInput.FillAsync(lastName);
            await EmailInput.FillAsync(email);
            await MobileNumberInput.FillAsync(mobile);
        }

        public async Task SelectGenderAsync(Gender gender)
        {
            await GenderRadio(gender).CheckAsync(new() { Force = true });
        }
        
        public async Task SelectHobbiesAsync(Hobbies hobby)
        {
            await HobbieCheck(hobby).CheckAsync();
        }
        

        public async Task SelectDateOfBirthAsync(string day, string month, string year)
        {
            await DateOfBirthInput.ClickAsync();
            await MonthsSelector.SelectOptionAsync(new SelectOptionValue { Label = month });
            await YearSelector.SelectOptionAsync(year);
            await DaysOfMonth.GetByText(day, new() { Exact = true }).ClickAsync();
        }

        public async Task AddSubjectAsync(string subject)
        {
            await SubjectInput.FillAsync(subject);
            await SubjectInput.PressAsync("Enter");
        }

        public async Task FillAddressAsync(string address)
        {
            await CurrentAddressInput.FillAsync(address);
        }

        public async Task SelectStateAndCityAsync(string state, string city)
        {
            await SelectStateInput.ClickAsync();
            await Page.GetByText(state, new() { Exact = true }).ClickAsync();
            await SelectCityInput.ClickAsync();
            await Page.GetByText(city, new() { Exact = true }).ClickAsync();
        }

        public async Task SelectSubjectAsync(string Subject)
        {
            await SubjectInput.FillAsync(Subject);
            await SubjectInput.PressAsync("Enter");
        }

        public async Task FillFormAsync(FormData data)
        {
            await FirstNameInput.FillAsync(data.FirstName);
            await LastNameInput.FillAsync(data.LastName);
            await EmailInput.FillAsync(data.Email);
            await MobileNumberInput.FillAsync(data.Mobile);
            await GenderRadio(data.Gender).CheckAsync(new() { Force = true });
            await HobbieCheck(data.Hobby).CheckAsync();
            await SelectDateOfBirthAsync(data.Days, data.Month, data.Year);
            await SelectSubjectAsync(data.Subject);
            await CurrentAddressInput.FillAsync(data.CurrentAddress);
            await SelectStateAndCityAsync(data.State, data.City);
                }

        public async Task Submit()
        {
            await SubmitButton.ClickAsync();
        }

    }
}