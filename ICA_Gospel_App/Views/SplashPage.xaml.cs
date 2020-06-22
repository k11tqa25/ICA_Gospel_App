using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected async override void OnAppearing()
        {
            // Insert MainPage before this page
            Navigation.InsertPageBefore(new MainPage(), this);

            // Prepare Everything
            InitializeEverything();

            // Popout this page
            await Navigation.PopAsync();
        }

        private  void InitializeEverything()
        {
             Task.Delay(1000);
        }
    }
}