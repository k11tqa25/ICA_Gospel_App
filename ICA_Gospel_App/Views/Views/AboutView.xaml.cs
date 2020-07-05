using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class AboutView : NavigatableView
        {
                public AboutView() : base()
                {
                        InitializeComponent();
                        Card.ScaleY = 0.4;
                        OnViewAppeared += AboutView_OnViewAppeared;
                        OnViewDisappeared += AboutView_OnViewDisappeared;
                }

                private void AboutView_OnViewDisappeared(EventArgs obj)
                {
                        Card.ScaleY = 0.4;
                }

                private void AboutView_OnViewAppeared(EventArgs obj)
                {
                        Card.ScaleYTo(1, 1000, Easing.SinInOut);
                }

                private void BackLabel_Tapped(object sender, EventArgs e)
                {
                        //MessagingCenter.Send<AboutView>(this, "Back");
                        Parent.BackToPrevious(DefaultAnimationBehavior.FadeInOut,
                                animateIn: true,
                                animateOut: true,
                                otherAnimations: Parent.OtherAnimationsReverse);
                }

        }
}