using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutoTestsForApplications.ForUI.Pages
{
    public class DemoQAHomePage
    {
        private readonly IPage Page;

        private ILocator FormsCard => Page.Locator(".card-body").Filter(new LocatorFilterOptions{HasText = "Forms"});

        public DemoQAHomePage (IPage page)
        {

            Page = page;

            }     

         public async Task OpenAsync()
        {
            await Page.GotoAsync("https://demoqa.com/");
        }
        public async Task GoForms()
        {
            await FormsCard.ClickAsync();
        }

    }
}