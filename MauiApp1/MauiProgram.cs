using MauiApp1.Services;
using MauiApp1.View_Model;
using Microsoft.Extensions.Logging;
using MVCClient.Services;
using P04WeatherForecastAPI.Client.Configuration;
using P06Shop.Shared.Services;

namespace MauiApp1
{
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
			ConfigureServices(builder.Services);
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

		private static void ConfigureServices(IServiceCollection services)
		{
			var appSettingsSection = ConfigureAppSettings(services);
			ConfigureAppServices(services, appSettingsSection);
			ConfigureViewModels(services);
			ConfigureViews(services);
			ConfigureHttpClients(services, appSettingsSection);
		}

		private static AppSettings ConfigureAppSettings(IServiceCollection services)
		{
			// pobranie appsettings z konfiguracji i zmapowanie na klase AppSettings 
			//Microsoft.Extensions.Options.ConfigurationExtensions
			//var appSettings = _configuration.GetSection(nameof(AppSettings));
			//var appSettingsSection = appSettings.Get<AppSettings>();
			// services.Configure<AppSettings>(appSettings);
			var appSettingsSection = new AppSettings()
			{
				BaseAPIUrl = "https://mwo4.azurewebsites.net/",
				CarBrandsEndpoint = new CRUDEndpoints()
				{
					Base_url = "api/CarBrand/",
					GetAll = "",
					Create = "",
					Update = "{0}",
					Delete = "{0}",
				}
			};
			services.AddSingleton(appSettingsSection);

			return appSettingsSection;
		}

		private static void ConfigureAppServices(IServiceCollection services, AppSettings appSettings)
		{
			services.AddSingleton<IConnectivity>(Connectivity.Current);
			services.AddSingleton<IGeolocation>(Geolocation.Default);
			services.AddSingleton<IMap>(Map.Default);

			// konfiguracja serwisów 
			services.AddSingleton<ICarBrandService, CarBrandService>();
			services.AddSingleton<IMessageDialogService, MauiMessageDialogService>();

		}

		private static void ConfigureViewModels(IServiceCollection services)
		{

			// konfiguracja viewModeli 


			services.AddSingleton<CarBrandViewModel>();

			// services.AddSingleton<BaseViewModel,MainViewModelV3>();
		}

		private static void ConfigureViews(IServiceCollection services)
		{
			// konfiguracja okienek 
			services.AddSingleton<MainPage>();
			services.AddSingleton<CarBrandView>();
		}

		private static void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
		{
			var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
			{
				Path = appSettingsSection.CarBrandsEndpoint.Base_url
			};
			//Microsoft.Extensions.Http
			services.AddScoped(client => new HttpClient { BaseAddress = uriBuilder.Uri });
		}
	}
}
