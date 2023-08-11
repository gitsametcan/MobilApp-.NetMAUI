﻿using FrontendWorks.Service;
using FrontendWorks.ViewModel;
using FrontendWorks.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FrontendWorks;

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

        builder.Services.AddScoped<ILoginRepo, LoginServices>();
        builder.Services.AddScoped<IPolicyRepo, PolicyService>();
        builder.Services.AddSingleton<LoginServices> ();
		builder.Services.AddSingleton<PolicyService> ();
        


		
		//Views
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<ContactPage>();
        builder.Services.AddSingleton<AboutPage>();
		builder.Services.AddSingleton<LoadingPage>();


		//View Models
		
        builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<LoadingPageViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
