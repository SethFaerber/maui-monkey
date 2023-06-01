﻿using Microsoft.Extensions.Logging;
using MonkeyFinder.Services;
using MonkeyFinder.View;
// using UIKit;

namespace MonkeyFinder;

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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<MonkeyService>();

		builder.Services.AddSingleton<MonkeysViewModel>();
		builder.Services.AddTransient<MonkeyDetailsViewModel>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}
