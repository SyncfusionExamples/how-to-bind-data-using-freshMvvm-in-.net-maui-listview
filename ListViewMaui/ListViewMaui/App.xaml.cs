using FreshMvvm.Maui;

namespace ListViewMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        var page = FreshPageModelResolver.ResolvePageModel<ListViewPageModel>();
        var basicNavContainer = new FreshNavigationContainer(page);
        MainPage = basicNavContainer;

    }
}
