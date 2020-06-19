using ICA_Gospel_App.Views;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ICA_Gospel_App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel mainPageVM;
        double density;
        double pageHeight;
        double pageWidth;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = mainPageVM = MainPageViewModelLocator.MainPageViewModel;

            density = DeviceDisplay.MainDisplayInfo.Density;
            pageHeight = DeviceDisplay.MainDisplayInfo.Height / density;
            pageWidth = DeviceDisplay.MainDisplayInfo.Width / density;
            AutoPlay(1);
        }

        private async void AutoPlay(double sec)
        {
            await Task.Delay((int)(sec * 1000));

            BackgroundMedia.Play();
        }


        private void TeachButton_Clicked(object sender, EventArgs e)
        {
            AnimateToPage2Layout();
        }

        private void BackLabel_Tapped(object sender, EventArgs e)
        {
            AnimateToPage1Layout();
        }

        private void ShareButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SlideShowPage());
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
            Animation fadeOut2 = new Animation(
                v => BackLabel.Opacity = v, 1, 0, Easing.SinInOut);

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
            parentAnimation.Add(0, .5, fadeOut2);
            parentAnimation.Add(0, .8, zoomOut);

            parentAnimation.Commit(Layout, "SwitchToPage1", 16, 2000, easing: Easing.SinInOut);
        }

        #endregion

    }
}
