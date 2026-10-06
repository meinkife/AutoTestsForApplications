using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using AutoTestsForApplications.ForUI.Fixtures;
using AutoTestsForApplications.ForUI.Pages;

namespace AutoTestsForApplications.Tests.UI_Tests
{
    public class PurchaseScenarioTests : BaseTest
    {
        [Test]
        public async Task FullPurchaseScenario()
        {
            var loginPage = new LoginPage(Page);
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);
            var checkoutPage = new CheckoutPage(Page);
            var overviewPage = new OverviewPage(Page);
            var completePage = new CompletePage(Page);

            
            string item1 = "Sauce Labs Backpack";
            string item2 = "Sauce Labs Bike Light";

           
            await loginPage.OpenAsync();
            await loginPage.LoginAsync("standard_user", "secret_sauce");
            
           
            (await productsPage.IsProductsTitleVisibleAsync()).Should().BeTrue();

            
            await productsPage.AddToCartAsync(item1);
            await productsPage.AddToCartAsync(item2);

            
            await productsPage.GoToCartAsync();
            (await cartPage.IsItemInCartAsync(item1)).Should().BeTrue();
            (await cartPage.IsItemInCartAsync(item2)).Should().BeTrue();

            
            await cartPage.ClickCheckoutAsync();

          
            await checkoutPage.FillFormAsync("Ilya", "Turgenev", "440013");

            
            (await overviewPage.IsItemInOverviewAsync(item1)).Should().BeTrue();
            (await overviewPage.IsItemInOverviewAsync(item2)).Should().BeTrue();

            
            await overviewPage.ClickFinishAsync();

           
            (await completePage.IsThankYouVisibleAsync()).Should().BeTrue();
        }
    }
}