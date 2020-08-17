
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class ChangeOrientationPage : ContentPage
        {
                private double width = 0;
                private double height = 0;

                public ChangeOrientationPage()
                {
                        InitializeComponent();
                        width = this.Width;
                        height = this.Height;
                }

                protected override void OnSizeAllocated(double width, double height)
                {
                        base.OnSizeAllocated(width, height); // have to call the base

                        if (this.width != width || this.height != height)
                        {
                                this.width = width;
                                this.height = height;

                                UpdateLayout();
                        }
                }

                private async void UpdateLayout()
                {
                        var mview = mViewContainer;
                        mSection1.IsVisible = width > height;
                        mPortraitView.IsVisible = width <= height;
                        if (width > height)
                                await mViewContainer.SwitchView(mSection1);
                        else
                                await mViewContainer.SwitchView(mPortraitView);
                }


        }
}