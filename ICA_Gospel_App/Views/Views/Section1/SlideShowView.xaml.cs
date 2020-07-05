using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class SlideShowView : NavigatableView
        {
                public SlideShowView()
                {
                        InitializeComponent();
                }

                private void GoButton_Clicked(object sender, EventArgs e)
                {
                        Parent.PopViewAsync(DefaultAnimationBehavior.ScaleFromLargeAndFadeInOut);
                }

                private void BackButton_Clicked(object sender, EventArgs e)
                {
                        Navigation.PopAsync();
                }
        }
}