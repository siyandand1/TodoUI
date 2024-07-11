namespace LoginFlowMAUI.Pages;

public partial class NewPage : ContentPage
{
	public NewPage()
	{
		InitializeComponent();
	}
    private async void HomeButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}