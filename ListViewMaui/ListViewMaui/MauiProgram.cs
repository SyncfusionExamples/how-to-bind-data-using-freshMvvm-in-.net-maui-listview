using FreshMvvm.Maui.Extensions;
using Syncfusion.Maui.Core.Hosting;
namespace ListViewMaui;

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
        builder.ConfigureSyncfusionCore();
        builder.Services.AddTransient<ListViewPage>();
		builder.Services.AddTransient<ListViewPageModel>();
        MauiApp mauiApp = builder.Build();
        mauiApp.UseFreshMvvm();
        
		return mauiApp;
	}
}
