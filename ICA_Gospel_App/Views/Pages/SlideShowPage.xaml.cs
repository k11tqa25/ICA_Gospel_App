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

        protected  override void OnDisappearing()
        {
            //base.OnDisappearing();
            this.FadeTo(0, 1000, Easing.SinIn);
            this.ScaleTo(1.4, 1000, Easing.SinIn);
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}