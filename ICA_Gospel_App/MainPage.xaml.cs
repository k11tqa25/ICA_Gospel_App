using ICA_Gospel_App.MessageHelpers;
using ICA_Gospel_App.Views;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICA_Gospel_App
{
    public partial class MainPage : ContentPage
    {
        MainPageView mainPageView;

        public MainPage()
        {
            InitializeComponent();
                        
            Content = new SplashView();
            mainPageView = new MainPageView();

            MessagingCenter.Subscribe<AppEventMesseges>(this, AppEventMesseges.Resumed, (_ => RunSplash(false)));

            Task.Run(() => RunSplash());
        }

        private async void RunSplash(bool wait = true)
        {
            if(wait)
                await Task.Delay(3000);

            Dispatcher.BeginInvokeOnMainThread(() => { 
                Content = mainPageView;
                mainPageView.FadeIn();
            });
          
        }


    }
}
