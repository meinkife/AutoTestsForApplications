using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutoTestsForApplications.ForUI.Pages
{
    public class OverviewPage
    {
        private readonly IPage Page;

        private ILocator CartList => Page.Locator(".cart_list");
        private ILocator FinishButton => Page.GetByRole(AriaRole.Button, new() { Name = "Finish" });

        public OverviewPage(IPage page) { Page = page; }

        public async Task<bool> IsItemInOverviewAsync(string productName)
        {
            return await CartList.Filter(new() { HasText = productName }).IsVisibleAsync();
        }

        public async Task ClickFinishAsync()
        {
            await FinishButton.ClickAsync();
        }
    }
}