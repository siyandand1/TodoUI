using LoginFlowMAUI.Pages;

namespace LoginFlowMAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new HomePageViewModel();
    }
}

