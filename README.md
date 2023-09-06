# how-to-bind-data-using-freshMvvm-in-.net-maui-listview

This demo explains about how to bind the data using FreshMVVM in .NET MAUI ListView

## C#

//Model.cs
 public class Contacts : FreshBasePageModel
    {
        private string contactName;
        private string contactNumber;
        private ImageSource image;

        public Contacts(string name, string number)
        {
            contactName = name;
            contactNumber = number;
        }

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

        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                if (contactNumber != value)
                {
                    contactNumber = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public ImageSource ContactImage
        {
            get { return this.image; }
            set
            {
                this.image = value;
                this.RaisePropertyChanged();
            }
        }
    }

// ViewModel.cs
public class ListViewPageModel : FreshBasePageModel
{
    ---    
}

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
