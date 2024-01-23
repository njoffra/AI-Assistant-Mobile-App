using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;
using ProjectMobilne.ViewModels;
using ProjectMobilne.Views;

namespace ProjectMobilne;

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
		builder.Services.AddTransient<RegisterViewModel>();
		builder.Services.AddTransient<RegisterView>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginView>();
		builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
		{
			ApiKey = "AIzaSyAx6Q5hdsqdl7vch36iGfOxwm_CNRV8Q-U\r\n",
			AuthDomain = "mobilneproject.firebaseapp.com",

            Providers = new FirebaseAuthProvider[]
			{
				new EmailProvider()
			}
		}));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
