using ICA_Gospel_App.MessageHelpers;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageView : ContentView
    {
        private MainPageViewModel mainPageVM;
        double density;
        double pageHeight;
        double pageWidth;

        public MainPageView()
        {
            InitializeComponent();

            BindingContext = mainPageVM = MainPageViewModelLocator.MainPageViewModel;

            density = DeviceDisplay.MainDisplayInfo.Density;
            pageHeight = DeviceDisplay.MainDisplayInfo.Height / density;
            pageWidth = DeviceDisplay.MainDisplayInfo.Width / density;

            MessagingCenter.Subscribe<AppEventMesseges>(this, AppEventMesseges.Slept, (_ => Cover.Opacity = 1)) ;
            MessagingCenter.Subscribe<AboutView>(this, "Back",  (s) => {
                AboutPage.IsVisible = false;
                FadeIn(); }) ;
        }

        public  void FadeIn()
        {
            // Render media player
            BackgroundMedia.Opacity = 0;
            Layout.Opacity = 0;
            Layout.IsVisible = true;

            Cover.FadeTo(0, 2000, Easing.SinInOut);
            BackgroundMedia.ScaleTo(1, 500, Easing.SinInOut);
            Layout.FadeTo(1, 2000, Easing.SinInOut);
            BackgroundMedia.Opacity = 1;
        }

        private void TeachButton_Clicked(object sender, EventArgs e)
        {
            BackgroundMedia.Play();
            AnimateToPage2Layout();
        }

        private async void BackLabel_Tapped(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Animation scaleUp = new Animation(
                    v => BackLabel.Scale = v, 1, 1.1, Easing.SinInOut);
                Animation scaleDown = new Animation(
                    v => BackLabel.Scale = v, 1.1, 1, Easing.SinInOut);
                Animation fade = new Animation(
                    v => BackLabel.Opacity = v, 1, 0, Easing.SinInOut);
                Animation composite = new Animation();
                composite.Add(0, .5, scaleUp);
                //composite.Add(.5, 1, scaleDown);
                composite.Add(0, 1, fade);
                composite.Commit(this, "LabelTouchEffect", 16, 800, Easing.SinInOut);
            });
            AnimateToPage1Layout();
        }

        private void ShareButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SlideShowPage(), true);
        }

        private void GoToAboutPage_Clicked(object sender, EventArgs e)
        {
            Layout.IsVisible = false;
            AboutPage.IsVisible = true;
            AboutPage.FadeIn();
            BackgroundMedia.ScaleTo(1.2, 500, Easing.SinInOut);
        }

        #region Animations

        private void AnimateToPage2Layout()
        {
            double org_h2 = pageHeight * 2.0 / 6.0;
            double new_h2 = pageHeight * 2.0 / 6.0;
            double new_h3 = pageHeight * 2.0 / 6.0;
            double new_h4 = pageHeight * 1.0 / 6.0;

            Animation row1 = new Animation(
               v => Layout.RowDefinitions[1].Height = v, org_h2, new_h2, Easing.SinInOut);
            Animation row3 = new Animation(
               v => Layout.RowDefinitions[3].Height = v, 0, new_h3, Easing.SinInOut);
            Animation row4 = new Animation(
               v => Layout.RowDefinitions[4].Height = v, 0, new_h4, Easing.SinInOut);


            Animation fadeOut0 = new Animation(
                v => Title.Opacity = v, 1, 0, Easing.SinInOut);
            Animation fadeOut1 = new Animation(
                v => ShareButton.Opacity = v, .5, 0, Easing.SinInOut);
            Animation fadeOut2 = new Animation(
                v => AboutLabel.Opacity = v, 1, 0, Easing.SinInOut);
            Animation fadeIn1 = new Animation(
                v => Page2Buttons.Opacity = v, 0, .5, Easing.SinInOut);
            Animation fadeIn2 = new Animation(
                v => BackLabel.Opacity = v, 0, 1, Easing.SinInOut);

            Animation zoomIn = new Animation(
                v => BackgroundMedia.Scale = v, 1, 1.2, Easing.SinInOut);

            Animation parentAnimation = new Animation();

            parentAnimation.Add(.2, .7, row1);
            parentAnimation.Add(0, .8, row3);
            parentAnimation.Add(0, .8, row4);
            parentAnimation.Add(0, .5, fadeOut0);
            parentAnimation.Add(0, .5, fadeOut1);
            parentAnimation.Add(0, .5, fadeOut2);
            parentAnimation.Add(.5, 1, fadeIn1);
            parentAnimation.Add(.5, 1, fadeIn2);
            parentAnimation.Add(0, .8, zoomIn);

            parentAnimation.Commit(Layout, "SwitchToPage2", 16, 2000, easing: Easing.SinInOut);
        }

        private void AnimateToPage1Layout()
        {
            double org_h1 = pageHeight * 2.0 / 6.0;
            double org_h2 = pageHeight * 2.0 / 6.0;
            double org_h3 = pageHeight * 1.0 / 6.0;
            double new_h1 = pageHeight * 2.0 / 6.0;

            Animation row1 = new Animation(
               v => Layout.RowDefinitions[1].Height = v, org_h1, new_h1, Easing.SinInOut);
            Animation row3 = new Animation(
               v => Layout.RowDefinitions[3].Height = v, org_h2, 0, Easing.SinInOut);
            Animation row4 = new Animation(
               v => Layout.RowDefinitions[4].Height = v, org_h3, 0, Easing.SinInOut);


            Animation fadeIn0 = new Animation(
                v => Title.Opacity = v, 0, 1, Easing.SinInOut);
            Animation fadeIn1 = new Animation(
                v => ShareButton.Opacity = v, 0, .5, Easing.SinInOut);
            Animation fadeIn2 = new Animation(
                v => AboutLabel.Opacity = v, 0, 1, Easing.SinInOut);
            Animation fadeOut1 = new Animation(
                v => Page2Buttons.Opacity = v, .5, 0, Easing.SinInOut);
            //Animation fadeOut2 = new Animation(
            //    v => BackLabel.Opacity = v, 1, 0, Easing.SinInOut);

            Animation zoomOut = new Animation(
                v => BackgroundMedia.Scale = v, 1.2, 1, Easing.SinInOut);

            Animation parentAnimation = new Animation();

            parentAnimation.Add(.2, .7, row1);
            parentAnimation.Add(0, .8, row3);
            parentAnimation.Add(0, .8, row4);
            parentAnimation.Add(.5, 1, fadeIn0);
            parentAnimation.Add(.5, 1, fadeIn1);
            parentAnimation.Add(.5, 1, fadeIn2);
            parentAnimation.Add(0, .5, fadeOut1);
            //parentAnimation.Add(0, .5, fadeOut2);
            parentAnimation.Add(0, .8, zoomOut);

            parentAnimation.Commit(Layout, "SwitchToPage1", 16, 2000, easing: Easing.SinInOut);
        }

        #endregion

    }
}