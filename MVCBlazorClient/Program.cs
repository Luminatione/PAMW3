using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MVCBlazorClient;
using Microsoft.Extensions.Options;
using MVCClient.Services;
using P04WeatherForecastAPI.Client.Configuration;
using System;
using System.Net.Http;

namespace MVCBlazorClient;

public class Program
{
    public static void Main(string[] args)
    {
        BuildWebAssemblyHost(args).RunAsync();
    }

    public static WebAssemblyHost BuildWebAssemblyHost(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
        var appSettingsSection = appSettings.Get<AppSettings>();

        var carsURIBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
        {
            Path = appSettingsSection.CarsEndpoint.Base_url,
        };
        var carBrandsURIBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
        {
            Path = appSettingsSection.CarBrandsEndpoint.Base_url,
        };
        builder.Services.AddSingleton<IOptions<AppSettings>>(new OptionsWrapper<AppSettings>(appSettingsSection));

        builder.Services.AddScoped<ICarBrandService, CarBrandService>();
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = carBrandsURIBuilder.Uri });

        return builder.Build();
    }
}
