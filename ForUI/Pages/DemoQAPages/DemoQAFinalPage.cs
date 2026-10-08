using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using FluentAssertions;

namespace AutoTestsForApplications.ForUI.Pages
{ 
    public class DemoQAFinalPage
    {
        private readonly IPage Page;

        private ILocator ResultTitle => Page.GetByText("Thanks for submitting the form");
        private ILocator ResultTable => Page.GetByRole(AriaRole.Table);
        private ILocator ResultValue(string label) => ResultTable.Locator($"xpath=.//td[text()='{label}']/following-sibling::td");
        private ILocator CloseButton =>Page.GetByRole(AriaRole.Button, new() { Name = "Close" });

        public DemoQAFinalPage(IPage page)
        {

            Page = page;

        }

        public async Task<string> GetResultTitleAsync()
        {
            await ResultTitle.WaitForAsync();
            return await ResultTitle.InnerTextAsync();
        }

        public async Task<string> GetResultValueAsync(string label)
        {
            await ResultValue(label).WaitForAsync();
            return await ResultValue(label).InnerTextAsync();
        }
        public async Task CloseButtonAsync()
        {
            await CloseButton.ClickAsync();
        }
    }
}