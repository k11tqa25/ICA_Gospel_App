using MvvmHelpers;
using System.Collections;
using System.Collections.Specialized;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewContainer : ContentView, INavigationManager
    {
        #region ViewItems
        /// <summary>
        /// Bindable item source property. This is mainly used for adding views from xaml
        /// </summary>
        public static readonly BindableProperty ItemSourceProperty =
        BindableProperty.Create(
        propertyName: nameof(ItemSource),
        returnType: typeof(IEnumerable),
        declaringType: typeof(ViewContainer));

        /// <summary>
        /// The item source that needs to be added in the view stack.
        /// This is only used for add views from the xaml.
        /// </summary>
        public ObservableRangeCollection<NavigatableView> ItemSource
        {
            get { return (ObservableRangeCollection<NavigatableView>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        #endregion ViewItems 

        #region Public Properties

        public int CurrentIndex { get; private set; }

        public NavigatableView PreviousView { get; private set; }

        public NavigatableView CurrentView { get; private set; }

        #endregion

        #region Read-only Members

        /// <summary>
        /// The current stack of views.
        /// </summary>
        public ObservableRangeCollection<NavigatableView> ViewStack { get; private set; }

        #endregion

        #region Constructors

        public ViewContainer() : base()
        {
            InitializeComponent();
            ItemSource = new ObservableRangeCollection<NavigatableView>();
            ViewStack = new ObservableRangeCollection<NavigatableView>();
            ItemSource.CollectionChanged += ItemSource_CollectionChanged;
            ViewStack.CollectionChanged += ViewStack_CollectionChanged;
        }

        public ViewContainer(NavigatableView InitialView) : base()
        {
            InitializeComponent();
            ItemSource = new ObservableRangeCollection<NavigatableView>();
            ViewStack = new ObservableRangeCollection<NavigatableView>();
            ItemSource.CollectionChanged += ItemSource_CollectionChanged;
            ViewStack.CollectionChanged += ViewStack_CollectionChanged;
            PushViewAsync(InitialView);
        }

        #endregion

        #region Public Methods

        public async Task PushViewAsync(NavigatableView view, bool animateIn = true, bool animateOut = false, Animation otherAnimations = null)
        {
            // Add to stack
            ViewStack.Add(view);
            view.Parent = this;

            // Initialize the position 
            if (animateIn) view.InitializePosition();

            // Change the content view whenever the stack changes (always show the top one)
            ContentGrid.Children.Add(view);

            // Animate transition
            await AnimateTransitioning.CustomTransitioning(CurrentView, PreviousView, true, animateIn, animateOut, otherAnimations);
        }

        public async Task PushViewAsync(NavigatableView view, DefaultAnimationBehavior defaultAnimation, bool animateIn = true, bool animateOut = false, Animation otherAnimations = null)
        {
            // Add to stack
            ViewStack.Add(view);
            view.Parent = this;

            // TODO: Initialize the position 


            // Change the content view whenever the stack changes (always show the top one)
            ContentGrid.Children.Add(view);

            await AnimateTransitioning.DefaultTransitioning(
                    CurrentView,
                    defaultAnimation,
                    true,
                    animateIn || animateOut || otherAnimations != null,
                    (animateOut) ? PreviousView : null,
                    otherAnimations);
        }

        public Task PushMultiViews(NavigatableView[] views)
        {
            return Task.Run(() =>
            {
                ViewStack.AddRange(views);
                Dispatcher.BeginInvokeOnMainThread(() =>
                {
                    foreach (var view in views) ContentGrid.Children.Add(view);
                });
            });
        }

        public Task InsertView(NavigatableView view, int index)
        {
            return Task.Run(() =>
            {
                ViewStack.Insert(index, view);
                ContentGrid.Dispatcher.BeginInvokeOnMainThread(() =>
                {
                    ContentGrid.Children.Insert(index, view);
                });
            });
        }

        public async Task SwitchView(NavigatableView view, bool animateIn, bool animateOut, Animation otherAnimations)
        {
            // Remove from existing stack and grid
            ContentGrid.Children.Remove(view);
            ViewStack.Remove(view);

            // push a new one
            await PushViewAsync(view, animateIn, animateOut, otherAnimations);
        }

        public async Task SwitchView(int index, bool animateIn, bool animateOut, Animation otherAnimations)
        {
            // Restore the view 
            var view = ViewStack[index];

            // Remove from existing stack and grid
            ContentGrid.Children.RemoveAt(index);
            ViewStack.RemoveAt(index);

            // push a new one
            await PushViewAsync(view, animateIn, animateOut, otherAnimations);
        }

        public async Task PopViewAsync(bool animateIn = false, bool animateOut = true, Animation otherAnimations = null)
        {
            //TODO: Exception handling
            if (CurrentIndex > 0)
            {
                // Animate transition
                await AnimateTransitioning.CustomTransitioning(CurrentView, PreviousView, false, animateIn, animateOut, otherAnimations);

                // After awaiting, the thread will not be on the UI thread, thus needing the dispatcher
                // Change the content view whenever the stack changes (always show the top one)
                ContentGrid.Dispatcher.BeginInvokeOnMainThread(() =>
                {
                    ContentGrid.Children.Remove(CurrentView);

                    // Remove top view from stack
                    ViewStack.Remove(CurrentView);
                });
            }
        }

        public async Task PopViewAsync(DefaultAnimationBehavior defaultAnimation, bool animateIn = false, bool animateOut = true, Animation otherAnimation = null)
        {
            //TODO: Exception handling
            if (CurrentIndex > 0)
            {
                // Animate transition
                await AnimateTransitioning.DefaultTransitioning(
                        CurrentView,
                        defaultAnimation,
                        false,
                        animateIn || animateOut || otherAnimation != null,
                        (animateIn) ? PreviousView : null,
                        otherAnimation);

                await Task.Delay(1000);

                // After awaiting, the thread will not be on the UI thread, thus needing the dispatcher
                // Change the content view whenever the stack changes (always show the top one)
                ContentGrid.Dispatcher.BeginInvokeOnMainThread(() =>
                {
                    ContentGrid.Children.Remove(CurrentView);

                    // Remove top view from stack
                    ViewStack.Remove(CurrentView);
                });
            }
        }

        #endregion

        #region Private Methods


        #endregion

        private void ViewStack_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CurrentIndex = ViewStack.Count - 1;
            PreviousView = (CurrentIndex - 1 >= 0) ? ViewStack[CurrentIndex - 1] : null;
            CurrentView = ViewStack[CurrentIndex];
        }

        private async void ItemSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                await PushViewAsync(ItemSource[e.NewStartingIndex], animateIn:false);
            }
        }
    }
}