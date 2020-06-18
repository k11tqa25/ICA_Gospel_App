using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Render media element
            Device.SetFlags(new string[] { "MediaElement_Experimental" });
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
