using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICA_Gospel_App.Views
{
    public partial class NavigatableView : ContentView, IViewNavigation
    {
        /// <summary>
        /// The parent view container for this view
        /// This is used to manage the switching between views
        /// </summary>
        public INavigationManager Parent { get; set; }

        public NavigatableView()
        {
            InitializeComponent();
        }

        public virtual Task AnimateInAsCurrentView()
        {
            return Task.Run(() => { return; });
        }

        public virtual Task AnimateOutAsCurentView()
        {
            return Task.Run(() => { return; });
        }

        public virtual Task AnimateInAsPreviousView()
        {
            return Task.Run(() => { return; });
        }

        public Task AnimateOutAsPreviousView()
        {
            return Task.Run(() => { return; });
        }

        public virtual void InitializePosition()
        {
        }
    }
}