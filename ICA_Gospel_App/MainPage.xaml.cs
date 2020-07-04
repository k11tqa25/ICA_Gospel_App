using ICA_Gospel_App.MessageHelpers;
using ICA_Gospel_App.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICA_Gospel_App
{
    public partial class MainPage : ContentPage
    {
        ViewContainer vc = new ViewContainer();

        public MainPage()
        {
            InitializeComponent();

            Content = vc;

            // push the first view to the view container
            Task.Run(() => vc.PushViewAsync(new SplashView(), DefaultAnimationBehavior.FadeInOut));

            MessagingCenter.Subscribe<AppEventMesseges>(this, AppEventMesseges.Resumed,
                async _ => await vc.SwitchView(vc.CurrentView, true, false, null));

        }
    }
}
