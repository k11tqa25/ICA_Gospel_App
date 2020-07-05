using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
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
                }

                private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
                {
                        AnimationLabel aniLabel;
                        if (animationNumber == 0)
                        {
                                aniLabel = new AnimationLabel();
                                ContentLayout.Children.Add(aniLabel,3,1);
                                aniLabel.StartAnimation();
                        }
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
                                                otherAnimations: new Animation(v => ContentLayout.Scale = v, 1, currentScale, Easing.SinInOut));
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