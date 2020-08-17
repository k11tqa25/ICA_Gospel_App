using ICA_Gospel_App.ViewModels.Locators;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class SplashPage : ContentPage
        {
                MainPage mainPage;

                public SplashPage()
                {
                        InitializeComponent();
                }

                public SplashPage(MainPage page)
                {
                        InitializeComponent();
                        mainPage = page;
                        BindingContext = ViewModelLocators.MainPageViewModel;
                }

                private void SplashMedia_MediaEnded(object sender, System.EventArgs e)
                {
                        mainPage.StartMainPage();
                        Navigation.PopAsync();
                }
        }
}