using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class Section1 : NavigatableView
        {
                public Section1()
                {
                        InitializeComponent();

                        //mViewContainer.PushMultiViews(
                        //        new NavigatableView[]
                        //        {
                        //                new Section1_StoryView(),
                        //                new SlideShowView()
                        //        });

                }
        }
}