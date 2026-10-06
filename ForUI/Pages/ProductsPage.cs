using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutoTestsForApplications.ForUI.Pages
{
    public class ProductsPage
    {
        private readonly IPage Page;

        private ILocator ProductsTitle => Page.GetByText("Products");
        private ILocator CartLink => Page.Locator(".shopping_cart_link");

        public ProductsPage(IPage page) { Page = page; }

        public async Task AddToCartAsync(string productName)
        {
            await Page.Locator(".inventory_item")
                .Filter(new() { HasText = productName })
                .GetByRole(AriaRole.Button, new() { Name = "Add to cart" })
                .ClickAsync();
        }

        public async Task<bool> IsProductsTitleVisibleAsync()
        {
            return await ProductsTitle.IsVisibleAsync();
        }

        public async Task GoToCartAsync()
        {
            await CartLink.ClickAsync();
        }
    }
}