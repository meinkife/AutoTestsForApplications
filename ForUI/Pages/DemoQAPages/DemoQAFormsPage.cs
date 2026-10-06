using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutoTestsForApplications.ForUI.Pages
{
    public class DemoQAFormsPage
    {
        private readonly IPage Page;

        public ILocator FormsText => Page.GetByText("Please select an item from left to start practice.");
        private ILocator GoToPractice => Page.GetByText("Practice Form");


        public DemoQAFormsPage(IPage page)
        {

            Page = page;

        }



        public async Task GoToPracticeForms()
        {
            await GoToPractice.ClickAsync();
        }

    }
}