using LoginFlowMAUI.Pages;
using AutherService;
using Microsoft.Extensions.Logging;
using TodoServices;
using Realms;

namespace LoginFlowMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddScoped<AutherService.AuthService>();
		builder.Services.AddTransient<LoadingPage>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddScoped<ITodoService, TodoServices.TodoService>();
        builder.Services.AddSingleton<LocalStorage>();

        // Initialize Realm
        var config = new RealmConfiguration("login.realm")
        {
            SchemaVersion = 1
        };
        var realm = Realm.GetInstance(config);
        builder.Services.AddSingleton(realm);
        return builder.Build();
	}
}
