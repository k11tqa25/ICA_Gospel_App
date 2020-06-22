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
    public partial class AboutView : ContentView
    {

        public AboutView()
        {
            InitializeComponent();
        }

        public AboutView(ContentView parentView)
        {
            InitializeComponent();
        }

        public void FadeIn()
        {
            Title.Opacity = 0;
            BackLabel.Opacity = 0;
            Card.ScaleY = 0.4;
            AboutContent.Opacity = 0;

            Card.ScaleYTo(1, 1000, Easing.SinInOut);
            AboutContent.FadeTo(1, 1000, Easing.SinInOut);
            Title.FadeTo(1, 1000, Easing.SinInOut);
            BackLabel.FadeTo(1, 100, Easing.SinInOut);

        }

        private void BackLabel_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send<AboutView>( this, "Back");
        }
    }
}