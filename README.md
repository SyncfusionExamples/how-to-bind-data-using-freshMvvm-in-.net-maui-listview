# How to bind data using FreshMVVM in .NET MAUI ListView (SfListView)?

The [.NET MAUI ListView](https://www.syncfusion.com/maui-controls/maui-listview) allows you to integrate smoothly with the [FreshMVVM](https://github.com/XAM-Consulting/FreshMvvm.Maui) framework. Follow the steps below to bind data using FreshMVVM.

Step 1: Install the [FreshMvvm.Maui](https://www.nuget.org/packages/FreshMvvm.Maui) NuGet package in your shared code project.

Step 2: Design your XAML page with the name ending in "Page".

namespace ListViewXamarin
    {
        public partial class ListViewPage : ContentPage
        {
            public ListViewPage()
            {
                InitializeComponent();
            }
        }
    }
Step 3: Create a page model with a name ending with PageModel and inherit from the [FreshBasePageModel](https://github.com/XAM-Consulting/FreshMvvm.Maui/blob/main/src/FreshMvvm.Maui/FreshBasePageModel.cs). Ensure the page and page model have the same namespace.

using FreshMvvm.Maui;
    namespace ListViewMaui
    {
        public class ListViewPageModel : FreshBasePageModel
        {
            #region Properties
     
            public ObservableCollection<Contacts> Contactsinfo { get; set; }
     
            #endregion
     
            #region Constructor
     
            public ListViewPageModel()
            {
                Contactsinfo = new ObservableCollection<Contacts>();
                GenerateInfo();
            }
     
            public void GenerateInfo()
            {
                Random r = new Random();
                for (int i = 0; i < 30; i++)
                {
                    var contact = new Contacts(CustomerNames[i], r.Next(720, 799).ToString() + " - " + r.Next(3010, 3999).ToString());
                    contact.ContactImage = "people_circle" + (i % 19) + ".png";
                    Contactsinfo.Add(contact);
                }
            }
            #endregion
     
        }
    }
Step 4: Create a model class that inherits FreshBasePageModel and uses the RaisePropertyChanged method of the base class to raise the property changed notifier.

using FreshMvvm.Maui;
    namespace ListViewXamarin
    {
        public class Contacts : FreshBasePageModel
        {
            private string contactName;
     
            public Contacts()
            {
     
            }
     
            public string ContactName
            {
                get { return contactName; }
                set
                {
                    if (contactName != value)
                    {
                        contactName = value;
                        this.RaisePropertyChanged();
                    }
                }
            }
        }
    }
Step 5: Configure FreshMVVM with the host builder and register dependencies in the MauiProgram.cs file.

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
Step 6: Set the MainPage using the PageModel in your App.xaml.cs file.

public App()
    {
        InitializeComponent();
        var page = FreshPageModelResolver.ResolvePageModel<ListViewPageModel>();
        var basicNavContainer = new FreshNavigationContainer(page);
        MainPage = basicNavContainer;
    }
Step 7: Bind the ViewModel collection to the [SfListView.ItemSource](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.SfListView.html#Syncfusion_Maui_ListView_SfListView_ItemsSource) property.

<listView:SfListView x:Name="listView" 
                         ItemSize="70"
                         ItemsSource="{Binding Contactsinfo}" 
                         ItemSpacing="0,0,5,0">
    </listView:SfListView>


### Conclusion

I hope you enjoyed learning how to bind data using FreshMVVM in the .NET MAUI ListView (SfListView).

You can refer to our [.NET MAUI ListView feature tour](https://www.syncfusion.com/maui-controls/maui-listview) page to learn about its other groundbreaking feature representations. Explore our [.NET MAUI ListView documentation](https://help.syncfusion.com/maui/listview/getting-started) to understand how to present and manipulate data.

You can check out our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense "https://www.syncfusion.com/sales/teamlicense") page for current customers. If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to check out our .NET MAUI ListView and other .NET MAUI components.

Please let us know in the comments if you have any queries or require clarification. Contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://www.syncfusion.com/support/directtrac/incidents/), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
