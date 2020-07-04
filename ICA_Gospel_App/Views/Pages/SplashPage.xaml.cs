using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class SplashPage : ContentPage
        {
                public SplashPage(MainPage page)
                {
                        InitializeComponent();
                        Task.Run(async () =>
                        {
                                await Task.Delay(3000);
                                Dispatcher.BeginInvokeOnMainThread(() =>
                                {
                                        page.StartMainPage();
                                        Navigation.PopAsync();
                                });
                        });
                }
        }
}