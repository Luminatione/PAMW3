﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Configuration;
using P04WeatherForecastAPI.Client.Services.CarService;
using P04WeatherForecastAPI.Client.Services.ProductServices;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P04WeatherForecastAPI.Client.ViewModels;
using P06Shop.Shared.Services.CarService;
using P06Shop.Shared.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IServiceProvider _serviceProvider;
        IConfiguration _configuration;
        public App()
        {
            //wczytanie appsettings.json do konfiguracji 
            var builder = new ConfigurationBuilder()
              .AddUserSecrets<App>()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            _configuration = builder.Build();



            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = ConfigureAppSettings(services);
            ConfigureAppServices(services);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private AppSettings ConfigureAppSettings(IServiceCollection services)
        {
            // pobranie appsettings z konfiguracji i zmapowanie na klase AppSettings 
            //Microsoft.Extensions.Options.ConfigurationExtensions
            var appSettings = _configuration.GetSection(nameof(AppSettings));
            var appSettingsSection = appSettings.Get<AppSettings>();
            services.Configure<AppSettings>(appSettings);
            return appSettingsSection;
        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            // konfiguracja serwisów 
            services.AddSingleton<IAccuWeatherService, AccuWeatherService>();
            services.AddSingleton<IFavoriteCityService, FavoriteCityService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ICarService, CarService>();
            services.AddSingleton<ICarBrandService, CarBrandService>();
        }

        private void ConfigureViewModels(IServiceCollection services)
        {

            // konfiguracja viewModeli 
            services.AddSingleton<MainViewModelV4>();
            services.AddSingleton<FavoriteCityViewModel>();
            services.AddSingleton<ProductsViewModel>();
            services.AddSingleton<CarsViewModel>();
            services.AddSingleton<CarBrandsViewModel>();
            // services.AddSingleton<BaseViewModel,MainViewModelV3>();
        }

        private void ConfigureViews(IServiceCollection services)
        {
            // konfiguracja okienek 
            services.AddTransient<MainWindow>();
            services.AddTransient<FavoriteCitiesView>();
            services.AddTransient<CarsView>();
            services.AddTransient<ShopProductsView>();
            services.AddTransient<CarBrandView>();
        }

        private void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var productUriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                Path = appSettingsSection.BaseProductEndpoint.Base_url
            };
            var carUriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                Path = appSettingsSection.CarsEndpoint.Base_url
            };
            var carBrandUriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                Path = appSettingsSection.CarBrandsEndpoint.Base_url
            };
            //Microsoft.Extensions.Http
            services.AddHttpClient<IProductService, ProductService>(client => client.BaseAddress = productUriBuilder.Uri);
            services.AddHttpClient<ICarService, CarService>(client => client.BaseAddress = carUriBuilder.Uri);
            services.AddHttpClient<ICarBrandService, CarBrandService>(client => client.BaseAddress = carBrandUriBuilder.Uri);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
