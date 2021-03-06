﻿using ICA_Gospel_App.MessageHelpers;
using ICA_Gospel_App.Views;
using System.Net.Http.Headers;
using Xamarin.Forms;

namespace ICA_Gospel_App
{
        public partial class MainPage : ContentPage
        {
                ViewContainer vc = new ViewContainer();
                MainPageView mainPageView;
                SplashPage splash;

                public MainPage()
                {
                        InitializeComponent();
                        splash = new SplashPage(this);
                        mainPageView = new MainPageView();
                        Navigation.PushAsync(splash);
                        Navigation.InsertPageBefore(mainPageView, splash);

                        MessagingCenter.Subscribe<AppEventMesseges>(this, AppEventMesseges.Resumed,
                            async _ => await vc.SwitchView(vc.CurrentView, true, false, null));
                }

                public void StartMainPage()
                {                        
                        mainPageView.AnimateIn();
                }
        }
}
