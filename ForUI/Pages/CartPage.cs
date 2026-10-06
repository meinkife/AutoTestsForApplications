using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutoTestsForApplications.ForUI.Pages
{
    public class CartPage
    {
        private readonly IPage Page;

        private ILocator CartList => Page.Locator(".cart_list");
        private ILocator CheckoutButton => Page.GetByRole(AriaRole.Button, new() { Name = "Checkout" });

        public CartPage(IPage page) { Page = page; }

                public async Task<bool> IsItemInCartAsync(string productName)
        {
            return await CartList.Filter(new() { HasText = productName }).IsVisibleAsync();
        }

        public async Task ClickCheckoutAsync()
        {
            await CheckoutButton.ClickAsync();
        }
    }
}