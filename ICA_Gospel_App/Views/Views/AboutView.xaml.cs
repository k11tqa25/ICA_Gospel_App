using ICA_Gospel_App.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutView : AnimatableView
    {

        public AboutView(): base()
        {
            InitializeComponent();
        }

        private void BackLabel_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send<AboutView>(this, "Back");
        }

        #region Override Methods

        public override Task AnimateIn()
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

        public override Task AnimateOut()
        {
            return base.AnimateOut();
        }

        #endregion
    }
}