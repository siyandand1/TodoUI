using AutherService;

namespace LoginFlowMAUI.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly AutherService.AuthService _authService;

    public ProfilePage(AutherService.AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        _authService.Logout();
        Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}