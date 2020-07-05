using ICA_Gospel_App.MessageHelpers;
using ICA_Gospel_App.ViewModels.Locators;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class MainPageView : ContentPage
        {
                private MainPageViewModel mainPageVM;
                double density;
                double pageHeight;
                double pageWidth;

                public MainPageView() : base()
                {
                        InitializeComponent();

                        BindingContext = mainPageVM = ViewModelLocators.MainPageViewModel;

                        density = DeviceDisplay.MainDisplayInfo.Density;
                        pageHeight = DeviceDisplay.MainDisplayInfo.Height / density;
                        pageWidth = DeviceDisplay.MainDisplayInfo.Width / density;

                        MessagingCenter.Subscribe<AppEventMesseges>(this, AppEventMesseges.Slept, (_ => Cover.Opacity = 1));
                        //MessagingCenter.Subscribe<AboutView>(this, "Back", (s) =>
                        //{
                        //        mViewContainer.SwitchView(mMainButtonView, true, false, null);
                        //});

                        SetupBackgroundAnimations();
                        BackgroundMedia.Play();
                }

                private void SetupBackgroundAnimations()
                {
                        mViewContainer.OtherAnimations = new Animation(v => BackgroundMedia.Scale = v, 1, 1.3, Easing.SinInOut);
                        mViewContainer.OtherAnimationsReverse = new Animation(v => BackgroundMedia.Scale = v, 1.3, 1, Easing.SinInOut);
                }

                private void TeachButton_Clicked(object sender, EventArgs e)
                {
                        AnimateSlideUp();
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
                        AnimateSlideDown();
                }

                private async void ShareButton_Clicked(object sender, EventArgs e)
                {
                        ChangeOrientationPage orientationPage = new ChangeOrientationPage();
                        await Navigation.PushAsync(orientationPage);
                }

                private async void GoToAboutPage_Clicked(object sender, EventArgs e)
                {
                        SetupBackgroundAnimations();
                        await mViewContainer.SwitchView(mAboutView,
                         DefaultAnimationBehavior.FadeInOut,
                         animateIn: true,
                         animateOut: true,
                         otherAnimations: mViewContainer.OtherAnimations);
                }

                #region Animations

                private void AnimateSlideUp()
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

                private void AnimateSlideDown()
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

                public Animation ShowUpAnimation()
                {
                        Animation ani = new Animation();
                        Animation cover = new Animation(
                                v => Cover.Opacity = v, 1, 0, Easing.SinInOut);
                        Animation bkMediaSize = new Animation(
                                v => BackgroundMedia.Scale = v, 1.3, 1, Easing.SinInOut);
                        ani.Add(0, 1, cover);
                        ani.Add(0, 1, bkMediaSize);
                        return ani;

                }

                #endregion

                #region Events

                public void AnimateIn()
                {
                        // Initialize fade in state
                        BackgroundMedia.Opacity = 0;
                        Layout.Opacity = 0;
                        Layout.IsVisible = true;

                        // Animations
                        Cover.FadeTo(0, 1000, Easing.SinInOut);
                        BackgroundMedia.ScaleTo(1, 500, Easing.SinInOut);
                        Layout.FadeTo(1, 1000, Easing.SinInOut);
                        BackgroundMedia.Opacity = 1;
                }

                #endregion

        }
}