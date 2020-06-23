using ICA_Gospel_App.Interfaces;
using MvvmHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewContainer : ContentView, INavigationManager
    {

        #region Public Properties

        public ObservableCollection<AnimatableView> ViewStack { get; set; }

        public int CurrentIndex => ViewStack.Count - 1;

        public AnimatableView PreviousView => (CurrentIndex > 0) ? ViewStack[CurrentIndex - 1] : null;

        public AnimatableView CurrentView => (CurrentIndex >= 0) ? ViewStack[CurrentIndex] : null;

        #endregion

        public ViewContainer() : base()
        {
            InitializeComponent();
            ViewStack = new ObservableCollection<AnimatableView>();
            // Update the content whenever the stack changes
            ViewStack.CollectionChanged += ViewStack_CollectionChanged;
            Content = new AnimatableView();
        }

        public ViewContainer(AnimatableView InitialView)
        {
            InitializeComponent();
            ViewStack = new ObservableCollection<AnimatableView>();
            // Update the content whenever the stack changes
            ViewStack.CollectionChanged += ViewStack_CollectionChanged;
            PushViewAsync(InitialView);
        }

        #region Public Methods

        public Task PushViewAsync(AnimatableView view, bool animateIn = true, bool animateOut = false, Animation otherAnimations = null)
        {
            return Task.Run(() =>
            {
                // TODO: Animate transition
                if (animateIn) view.AnimateIn();
                if (animateOut) CurrentView.AnimateOut();
                otherAnimations?.Commit(CurrentView, nameof(otherAnimations));

                view.Parent = this;

                // Add to stack
                ViewStack.Add(view);
                //Dispatcher.BeginInvokeOnMainThread(() => Content = CurrentView);
            });
        }

        public Task PopViewAsync(bool animateIn = false, bool animateOut = true)
        {
            return Task.Run(() =>
            {
                // TODO: Animate transition
                if (animateOut) CurrentView.AnimateOut();
                if (animateIn) PreviousView?.AnimateIn();

                // Remove top view from stack
                ViewStack.RemoveAt(CurrentIndex);

                // Don't let the current view be null  
                if (CurrentIndex < 0) ViewStack.Add(new AnimatableView());

                // Change the content view whenever the stack changes (always show the top one)
                //Dispatcher.BeginInvokeOnMainThread(() => Content = CurrentView);
            });
        }

        #endregion



        private void ViewStack_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ViewStack.Count > 0)
            {
                // Change the content view whenever the stack changes (always show the top one)
                Dispatcher.BeginInvokeOnMainThread(() => Content = CurrentView);
            }
        }

    }
}