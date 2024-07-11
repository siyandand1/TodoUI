using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace LoginFlowMAUI.Pages
{
    public class HomePageViewModel : BindableObject
    {
        public ICommand Card1Command { get; }
        public ICommand Card2Command { get; }

        public HomePageViewModel()
        {
            Card1Command = new Command(async () => await NavigateToNewPage());
            Card2Command = new Command(async () => await ShowPopupMessage());
        }
       
        private async Task NavigateToNewPage()
        {
            // Navigate to a new page
            await Shell.Current.GoToAsync(nameof(NewPage)); // Ensure NewPage is registered in AppShell
        }

        private async Task ShowPopupMessage()
        {
            // Show a popup message
            await Application.Current.MainPage.DisplayAlert("Popup", "This is a popup message.", "OK");
        }
    }
}
