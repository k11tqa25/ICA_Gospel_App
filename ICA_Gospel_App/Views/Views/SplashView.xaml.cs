using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashView : NavigatableView
    {

        public SplashView() : base()
        {
            InitializeComponent();

            Splash();

        }

        private void Splash()
        {
            Task.Run(() =>
            {
                Task run = new Task(() =>
                {
                    Thread.Sleep(1000);
                });
                run.Start();
                run.Wait();
                Dispatcher.BeginInvokeOnMainThread(() => Parent.PushViewAsync(new MainPageView(), DefaultAnimationBehavior.FadeInOut, true));
            });

        }

    }
}