﻿using WeatherApp.Services;
using WeatherApp.ViewModels;
using WeatherApp.Views;
namespace WeatherApp;

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

        
        builder.Services.AddSingleton<WeatherService>();
        builder.Services.AddSingleton<WeatherViewModel>();
        builder.Services.AddTransient<MainPage>();

        return builder.Build();
    }
}