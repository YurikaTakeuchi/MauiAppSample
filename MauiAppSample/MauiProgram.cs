using MauiAppSample.Services;
using MauiAppSample.ViewModels;
using MauiAppSample.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Networking;

namespace MauiAppSample;

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

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

		builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<IAlertService, AlertService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
