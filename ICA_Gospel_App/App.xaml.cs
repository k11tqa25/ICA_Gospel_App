using ICA_Gospel_App.MessageHelpers;
using ICA_Gospel_App.Views;
using System;
using System.Diagnostics;
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
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            MessagingCenter.Send(new AppEventMesseges(), AppEventMesseges.Slept);
        }

        protected override void OnResume()
        {
            MessagingCenter.Send(new AppEventMesseges(), AppEventMesseges.Resumed);
        }
    }
}
