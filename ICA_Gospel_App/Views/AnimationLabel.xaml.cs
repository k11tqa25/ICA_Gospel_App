
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class AnimationLabel : ContentView
        {
                #region LottieAnimation
                public static readonly BindableProperty LottieAnimationProperty =
                BindableProperty.Create(
                propertyName: nameof(LottieAnimation),
                returnType: typeof(string),
                declaringType: typeof(AnimationLabel),
                propertyChanged: (obj, oldV, newV) =>
                  {
                          var me = obj as AnimationLabel;
                          if (newV != null && !(newV is string)) return;
                          var oldLottieAnimation = (string)oldV;
                          var newLottieAnimation = (string)newV;
                          me?.LottieAnimationChanged(oldLottieAnimation, newLottieAnimation);
                  });

                private void LottieAnimationChanged(string oldLottieAnimation, string newLottieAnimation)
                {
                        // property changed
                        mLottie.Animation = newLottieAnimation;
                }

                public string LottieAnimation
                {
                        get { return (string)GetValue(LottieAnimationProperty); }
                        set { SetValue(LottieAnimationProperty, value); }
                }

                #endregion LottieAnimation 

                #region PrimaryLabelText
                public static readonly BindableProperty PrimaryLabelTextProperty =
                BindableProperty.Create(
                propertyName: nameof(PrimaryLabelText),
                returnType: typeof(string),
                declaringType: typeof(AnimationLabel),
                propertyChanged: (obj, oldV, newV) =>
                  {
                          var me = obj as AnimationLabel;
                          if (newV != null && !(newV is string)) return;
                          var oldPrimaryLabelText = (string)oldV;
                          var newPrimaryLabelText = (string)newV;
                          me?.PrimaryLabelTextChanged(oldPrimaryLabelText, newPrimaryLabelText);
                  });

                private void PrimaryLabelTextChanged(string oldPrimaryLabelText, string newPrimaryLabelText)
                {
                        // property changed
                        PrimaryText.Text = newPrimaryLabelText;
                }

                public string PrimaryLabelText
                {
                        get { return (string)GetValue(PrimaryLabelTextProperty); }
                        set { SetValue(PrimaryLabelTextProperty, value); }
                }
                #endregion PrimaryLabelText 

                #region SecondaryLabelText
                public static readonly BindableProperty SecondaryLabelTextProperty =
                BindableProperty.Create(
                propertyName: nameof(SecondaryLabelText),
                returnType: typeof(string),
                declaringType: typeof(AnimationLabel),
                propertyChanged: (obj, oldV, newV) =>
                  {
                          var me = obj as AnimationLabel;
                          if (newV != null && !(newV is string)) return;
                          var oldSecondaryLabelText = (string)oldV;
                          var newSecondaryLabelText = (string)newV;
                          me?.SecondaryLabelTextChanged(oldSecondaryLabelText, newSecondaryLabelText);
                  });

                private void SecondaryLabelTextChanged(string oldSecondaryLabelText, string newSecondaryLabelText)
                {
                        // property changed
                        SecondaryText.Text = newSecondaryLabelText;
                }

                public string SecondaryLabelText
                {
                        get { return (string)GetValue(SecondaryLabelTextProperty); }
                        set { SetValue(SecondaryLabelTextProperty, value); }
                }
                #endregion SecondaryLabelText 

                public AnimationLabel()
                {
                        InitializeComponent();
                }

                public void StartAnimation()
                {
                        mLottie.Play();
                }
        }
}