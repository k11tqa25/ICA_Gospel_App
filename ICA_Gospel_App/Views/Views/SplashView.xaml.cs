
using ICA_Gospel_App.Extensions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashView : AnimatableView
    {

        public SplashView() : base()
        {
            InitializeComponent();
        }



        #region Override Methods

        public override Task AnimateIn()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);

                this.PushViewAnyc(new MainPageView());
            });             
        }

        public override Task AnimateOut()
        {
            return base.AnimateOut();
        }

        #endregion
    }
}