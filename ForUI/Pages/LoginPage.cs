using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutoTestsForApplications.ForUI.Pages
{
    public class LoginPage
    {
        private readonly IPage Page;

               private ILocator UserNameInput => Page.GetByPlaceholder("Username");
        private ILocator PasswordInput => Page.GetByPlaceholder("Password");
        private ILocator LoginButton => Page.GetByRole(AriaRole.Button, new() { Name = "Login" });

        public LoginPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenAsync()
        {
            await Page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task LoginAsync(string username, string password)
        {
            await UserNameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }
    }
}