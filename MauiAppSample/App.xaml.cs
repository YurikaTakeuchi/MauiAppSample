using MauiAppSample.Services;

namespace MauiAppSample;

public partial class App : Application
{
	public static IServiceProvider Services { get; private set; }
	public static IAlertService AlertService { get; private set; }
	public App(IServiceProvider provider)
	{
		InitializeComponent();

		Services = provider;
		AlertService = provider.GetService<IAlertService>();

		MainPage = new AppShell();
	}
}
