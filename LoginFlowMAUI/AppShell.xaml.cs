using LoginFlowMAUI.Pages;

namespace LoginFlowMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ListingPage), typeof(ListingPage));
		Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(NewPage), typeof(NewPage));

    }
    protected override async void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);

        // Start your custom animation
        if (args.Source == ShellNavigationSource.Push)
        {
            await Task.WhenAll(
                this.FadeTo(0, 250),  // Fade out
                this.TranslateTo(-Width, 0, 250)  // Slide left
            );
        }
    }

    protected override async void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);

        // Finish your custom animation
        if (args.Source == ShellNavigationSource.Push)
        {
            this.TranslationX = Width;  // Reset position
            await Task.WhenAll(
                this.FadeTo(1, 250),  // Fade in
                this.TranslateTo(0, 0, 250)  // Slide to position
            );
        }
    }
}
