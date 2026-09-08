using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutoTestsForApplications.ForUI.Pages
{
    public class CompletePage
    {
        private readonly IPage Page;

        private ILocator ThankYouMessage => Page.GetByText("Thank you for your order!");

        public CompletePage(IPage page) { Page = page; }

        public async Task<bool> IsThankYouVisibleAsync()
        {
            return await ThankYouMessage.IsVisibleAsync();
        }
    }
}