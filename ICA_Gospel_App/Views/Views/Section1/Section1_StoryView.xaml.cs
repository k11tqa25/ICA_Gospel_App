using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class Section1_StoryView : NavigatableView
        {
                private bool isVideoControlShown = false;
                private double startScale, currentScale;

                private int animationNumber = 0;

                public Section1_StoryView()
                {
                        InitializeComponent();
                        ManLabel.Opacity = 0;
                        ManLabel.Scale = 1.2;
                        Heart.Opacity = 0;
                }

                private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
                {
                        AnimationLabel aniLabel;
                        if (animationNumber == 0)
                        {
                                ContentLayout.ScaleTo(1, 500, Easing.SinInOut);
                                ContentLayout.TranslateTo(0, 0, 500, Easing.SinInOut);
                        }
                        else if (animationNumber == 1)
                        {
                                ManLabel.FadeTo(1, 500, Easing.SinInOut);
                                ManLabel.ScaleTo(1, 500, Easing.SinInOut);
                                Heart.FadeTo(1, 500, Easing.SinInOut);
                                Heart.Play();
                        }
                        else if (animationNumber == 2)
                        {
                                aniLabel = new AnimationLabel()
                                {
                                        HorizontalOptions = LayoutOptions.Center,
                                        VerticalOptions = LayoutOptions.Center
                                };
                                ContentLayout.Children.Add(aniLabel, 3, 1);
                                aniLabel.StartAnimation();

                        }
                        else if(animationNumber == 3)
                        {
                                aniLabel = new AnimationLabel()
                                {
                                        HorizontalOptions = LayoutOptions.Center,
                                        VerticalOptions = LayoutOptions.Center
                                };
                                aniLabel.PrimaryLabelText = "Eternal Lift";
                                aniLabel.SecondaryLabelText = "After We Die";
                                ContentLayout.Children.Add(aniLabel, 3, 2);
                                aniLabel.StartAnimation();
                        }
                        else if (animationNumber == 4)
                        {
                                aniLabel = new AnimationLabel()
                                {
                                        HorizontalOptions = LayoutOptions.Center,
                                        VerticalOptions = LayoutOptions.Center
                                };
                                aniLabel.PrimaryLabelText = "Free Choice";
                                ContentLayout.Children.Add(aniLabel, 0, 1);
                                aniLabel.StartAnimation();
                        }
                        animationNumber++;
                }

                private async void PinchGestureRecognizer_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
                {
                        if (e.Status == GestureStatus.Started)
                        {
                                startScale = ContentLayout.Scale;
                        }
                        if (e.Status == GestureStatus.Running)
                        {
                                // Calculate the scale factor to be applied.
                                currentScale += (e.Scale - 1) * startScale;
                                currentScale = currentScale.Clamp(.8, 1.5);

                        }
                        if (e.Status == GestureStatus.Completed)
                        {
                                if (currentScale < 1 && !isVideoControlShown)
                                {
                                        await mViewContainer.PushViewAsync(new VideoControlView(),
                                                DefaultAnimationBehavior.ScaleFromLargeAndFadeInOut,
                                                otherAnimations: new Animation(v => ContentLayout.Scale = v, 1, startScale * currentScale, Easing.SinInOut));
                                        isVideoControlShown = true;

                                }
                                else if (currentScale > 1 && isVideoControlShown)
                                {
                                        await mViewContainer.PopViewAsync(DefaultAnimationBehavior.ScaleFromLargeAndFadeInOut,
                                                otherAnimation: new Animation(v => ContentLayout.Scale = v, startScale, 1, Easing.SinInOut));

                                        isVideoControlShown = false;
                                }
                        }

                }
        }
}