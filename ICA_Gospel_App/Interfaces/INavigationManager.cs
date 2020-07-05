using ICA_Gospel_App.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICA_Gospel_App
{
        public interface INavigationManager
        {
                /// <summary>
                /// Store other animation so that it can be used in many places.
                /// </summary>
                Animation OtherAnimations { get; set; }

                /// <summary>
                /// Store the reverse of other animations so that it can be used in many places.
                /// </summary>
                Animation OtherAnimationsReverse { get; set; } 

                /// <summary>
                /// Push a view to the stack with customized animation.
                /// </summary>
                /// <param name="view">The view to be push to the stack</param>
                /// <param name="animateIn">True to animate in the new view.  This will call the AnimateInAsCurrentView method of a NavigatableView</param>
                /// <param name="animateOut">True to animate out the current view. This will call the AnimateOutPreviouView method of a NavigatableView</param>
                /// <param name="otherAnimations">Other animations that need to be incorporate</param>
                /// <returns></returns>
                Task PushViewAsync(NavigatableView view, bool animateIn = true, bool animateOut = false, Animation otherAnimations = null);

                /// <summary>
                /// Push a view to the stack. Will add in a view with animation by default.
                /// </summary>
                /// <param name="view"> The view to be push to the stack.</param>
                /// <param name="defaultAnimation">Select a default animation from <see cref="DefaultAnimationBehavior"/></param>
                /// <param name="animateIn">True to animate in the new view.</param>
                /// <param name="animateOut">True to animate out the current view.</param>
                /// <param name="otherAnimation">Other animations that need to be incorporate</param>
                /// <returns></returns>
                Task PushViewAsync(NavigatableView view, DefaultAnimationBehavior defaultAnimation, bool animateIn = true, bool animateOut = false, Animation otherAnimations = null);

                /// <summary>
                /// Push a bunch of views into the stack. This is useful for preparing a stack of views in advance and then switch between views.
                /// </summary>
                /// <param name="views">The array of views to push to the stack</param>
                /// <returns></returns>
                Task PushMultiViews(NavigatableView[] views);

                /// <summary>
                /// Insert view to a specific index
                /// </summary>
                /// <param name="view">The view to insert.</param>
                /// <param name="index">The index to inset.</param>
                /// <returns></returns>
                Task InsertView(NavigatableView view, int index);

                /// <summary>
                /// Set certain view to become the view to display.
                /// </summary>
                /// <param name="view">The view to display</param>
                /// <param name="animateIn">True to animate in the new view.</param>
                /// <param name="animateOut">True to animate out the current view</param>
                /// <param name="otherAnimation">Other animations that need to be incorporate.</param>
                /// <returns></returns>
                Task SwitchView(NavigatableView view, bool animateIn = false, bool animateOut = false, Animation otherAnimations = null);

                /// <summary>
                /// Set certain view to become the view to display.
                /// </summary>
                /// <param name="view">The view to display</param>
                /// <param name="defaultAnimation">Switch view with default animations</param>
                /// <param name="animateIn">True to animate in the new view.</param>
                /// <param name="animateOut">True to animate out the current view</param>
                /// <param name="otherAnimations">Other animations that need to be incorporate.</param>
                /// <returns></returns>
                Task SwitchView(NavigatableView view, DefaultAnimationBehavior defaultAnimation, bool animateIn = false, bool animateOut = false, Animation otherAnimations = null);

                /// <summary>
                /// Set certain index view to become the view to display by index.
                /// </summary>
                /// <param name="index">The index of the view to display</param>
                /// <param name="animateIn">True to animate in the new view.</param>
                /// <param name="animateOut">True to animate out the current view</param>
                /// <param name="otherAnimations">Other animations that need to be incorporate.</param>
                /// <returns></returns>
                Task SwitchView(int index, bool animateIn = false, bool animateOut = false, Animation otherAnimations = null);

                /// <summary>
                /// Pop out the current view from the stack. If this is the last view,  this will fail an throw an exception.
                /// </summary>
                /// <param name="animateIn">True to animate in the new view.</param>
                /// <param name="animateOut">True to animate out the current view.</param>
                /// <param name="otherAnimations">Other animations that need to be incorporate.</param>
                /// <returns></returns>
                Task PopViewAsync(bool animateIn = false, bool animateOut = true, Animation otherAnimations = null);

                /// <summary>
                /// Pop out the current view from the stack. If this is the last view,  this will fail an throw an exception.
                /// </summary>
                /// <param name="defaultAnimation">Select a default animation from <see cref="DefaultAnimationBehavior"/></param>
                /// <param name="animateIn">True to animate in the new view.</param>
                /// <param name="animateOut">True to animate out the current view.</param>
                /// <param name="otherAnimations">Other animations that need to be incorporate.</param>
                /// <returns></returns>
                Task PopViewAsync(DefaultAnimationBehavior defaultAnimation, bool animateIn = false, bool animateOut = true, Animation otherAnimations = null);

                /// <summary>
                /// Go back to previous view.
                /// </summary>
                /// <param name="defaultAnimation">Set to none if you want to use the custom animation.</param>
                /// <param name="animateIn">True to animate in the new view.</param>
                /// <param name="animateOut">True to animate out the current view.</param>
                /// <param name="otherAnimations">Other animations that need to be incorporate.</param>
                /// <returns></returns>
                Task BackToPrevious(DefaultAnimationBehavior defaultAnimation = DefaultAnimationBehavior.None, bool animateIn = true, bool animateOut = false, Animation otherAnimations = null); 
        }
}
