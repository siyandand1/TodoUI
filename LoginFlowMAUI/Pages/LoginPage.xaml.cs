using AutherService;

namespace LoginFlowMAUI.Pages;

public partial class LoginPage : ContentPage
{
    private readonly AutherService.AuthService _authService;

    public LoginPage(AutherService.AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
        BindingContext = new LoginViewModel(_authService);
    }

    public LoginPage()
    {

        BindingContext = new LoginViewModel(_authService);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
       //  _authService.OnLogin();

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}