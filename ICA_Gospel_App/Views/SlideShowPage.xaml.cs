using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlideShowPage : ContentPage
    {
        public SlideShowPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.FadeTo(1, 1000, Easing.SinIn);
        }

        protected async override void OnDisappearing()
        {
            //base.OnDisappearing();
            await this.TranslateTo(this.Width, this.Y, 2000);
        }
    }
}