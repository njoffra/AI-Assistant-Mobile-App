using ChatGptNet;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;
using ProjectMobilne.ViewModels;
using ProjectMobilne.Views;
using ChatGptNet.Models;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using ProjectMobilne.Services;
using PanCardView;
using CommunityToolkit.Maui;
using ProjectMobilne.Data;

namespace ProjectMobilne;

public static class MauiProgram
{
    public static string CurrentGptModelEmbedding { get; set; }
    public static string CurrentGptModel { get; set; }
    public static MauiApp CreateMauiApp()
	{

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseCardsView()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Nexa-ExtraLight.ttf", "NexaLight");
                fonts.AddFont("Nexa-Heavy.ttf", "NexaHeavy");
            });
		builder.AddAppSettings();
		builder.Services.AddTransient<RegisterViewModel>();
		builder.Services.AddTransient<RegisterView>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginView>();
        //builder.Services.AddTransient<ChatViewModel>();
        builder.Services.AddTransient<NewChatView>();
        builder.Services.AddScoped<NewChatViewModel>();
        builder.Services.AddTransient<ChatView>();
        builder.Services.AddTransient<ImageView>();
        builder.Services.AddTransient<IApiService, ApiService>();
		builder.Services.AddTransient<IProfileService, ProfileService>();
        builder.Services.AddSingleton<Profiles>();
        string firebase_api_key = builder.Configuration.GetValue<string>("FIREBASE_API_KEY");
		string firebase_auth_domain = builder.Configuration.GetValue<string>("FIREBASE_AUTH_DOMAIN");
		string openai_api_key = builder.Configuration.GetValue<string>("OPENAI_API_KEY");
		
		builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
		{
			ApiKey = firebase_api_key,
			AuthDomain = firebase_auth_domain,

			Providers = new FirebaseAuthProvider[]
			{
				new EmailProvider()
			}
		})) ;
        builder.Services.AddChatGpt(options =>
        {
            // OpenAI.
            options.UseOpenAI(apiKey: openai_api_key, organization: "");

            // Azure OpenAI Service.
            //options.UseAzure(resourceName: "", apiKey: "", authenticationType: AzureAuthenticationType.ApiKey);

            options.DefaultModel = CurrentGptModel;
            options.DefaultEmbeddingModel = CurrentGptModelEmbedding;
            options.MessageLimit = 16;  // Default: 10
            options.MessageExpiration = TimeSpan.FromMinutes(5);    // Default: 1 hour
            options.DefaultParameters = new ChatGptParameters
            {
                MaxTokens = 800,
                Temperature = 0.7
            };
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	private static void AddAppSettings(this MauiAppBuilder builder)
	{
		using Stream stream = Assembly
			.GetExecutingAssembly()
			.GetManifestResourceStream("ProjectMobilne.appsettings.json");
		if(stream != null)
		{
			IConfigurationRoot config = new ConfigurationBuilder()
				.AddJsonStream(stream)
				.Build();
			builder.Configuration.AddConfiguration(config);
		}

	}

}
