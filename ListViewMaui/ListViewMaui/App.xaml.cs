using FreshMvvm.Maui;

namespace ListViewMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var page = FreshPageModelResolver.ResolvePageModel<ListViewPageModel>();
        var basicNavContainer = new FreshNavigationContainer(page);
        return new Window(basicNavContainer);
    }
}
