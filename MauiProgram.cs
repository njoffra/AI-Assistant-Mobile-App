using ChatGptNet;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;
using ProjectMobilne.ViewModels;
using ProjectMobilne.Views;
using ChatGptNet;
using ChatGptNet.Models;

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
        builder.Services.AddChatGpt(options =>
        {
            options.ApiKey = "<your-api-key-here>";
            options.Organization = null; // Optional
            options.DefaultModel = ChatGptModels.Gpt35Turbo; // Default: ChatGptModels.Gpt35Turbo
            options.MessageLimit = 10; // Default: 10
            options.MessageExpiration = TimeSpan.FromMinutes(5); // Default: 1 hour
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
