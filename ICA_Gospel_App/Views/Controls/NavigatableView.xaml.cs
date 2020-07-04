using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICA_Gospel_App.Views
{
        public partial class NavigatableView : ContentView, IViewNavigation
        {
                #region Private Properties

                private bool _appeared;

                #endregion

                #region Public Properties
                /// <summary>
                /// The parent view container for this view
                /// This is used to manage the switching between views
                /// </summary>
                public INavigationManager Parent { get; set; }

                public double DefaultScaleFromSmallerRatio { get; set; } = 0.7;

                public double DefaultScaleFromLargerRatio { get; set; } = 1.3;

                public double DefaultFadeOutOpacity { get; set; } = 0.0;

                public bool Appeared
                {
                        get => _appeared;
                        set
                        {
                                if (value) OnViewAppeared.Invoke(new EventArgs());
                                else OnViewDisappeared(new EventArgs());
                                _appeared = value;
                        }
                }

                #endregion

                public NavigatableView()
                {
                        InitializeComponent();
                }

                #region Public Methods

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

                #endregion

                #region Events

                public event Action<EventArgs> OnViewAppeared = (e) => { };

                public event Action<EventArgs> OnViewDisappeared = (e) => { };

                #endregion
        }
}