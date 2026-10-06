using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using FluentAssertions;

namespace AutoTestsForApplications.ForUI.Pages
{ 
    public class DemoQAFinalPage
    {
        private readonly IPage Page;

    public ILocator ResultTitle => Page.GetByText("Thanks for submitting the form");
    public ILocator ResultTable => Page.GetByRole(AriaRole.Table);
    private ILocator CloseButton =>Page.GetByRole(AriaRole.Button, new() { Name = "Close" });

        public DemoQAFinalPage(IPage page)
        {

            Page = page;

        }

      
        public async Task CloseButtonAsync()
        {
            await CloseButton.ClickAsync();
        }
    }
}