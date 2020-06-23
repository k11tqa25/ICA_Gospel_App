using ICA_Gospel_App.MessageHelpers;
using ICA_Gospel_App.Views;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICA_Gospel_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Content = new ViewContainer(new MainPageView());

            MessagingCenter.Subscribe<AppEventMesseges>(this, AppEventMesseges.Resumed, 
                _ => (Content as ViewContainer).CurrentView.AnimateIn());

        }
    }
}
