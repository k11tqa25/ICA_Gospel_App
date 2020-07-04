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
        }

        private void BackLabel_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send<AboutView>(this, "Back");
        }

        #region Override Methods

        public override Task AnimateInAsCurrentView()
        {
            return Task.Run(() =>
            {
                // Initialize animation state
                this.Opacity = 0;
                Card.ScaleY = 0.4;

                // Animate
                this.FadeTo(1, 500, Easing.SinInOut);
                Card.ScaleYTo(1, 1000, Easing.SinInOut);
            });
        }

        #endregion
    }
}