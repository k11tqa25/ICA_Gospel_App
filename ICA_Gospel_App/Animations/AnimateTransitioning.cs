using ICA_Gospel_App.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICA_Gospel_App
{
        public static class AnimateTransitioning
        {
                /// <summary>
                ///  Handle the customized animation transitioning. 
                ///  If the <paramref name="pushOrPop"/> is set to true, the current view will call its "AnimateInAsCurrentView"
                ///  and the previous view will call its "AnimateOutAsPreviousView" event.
                ///  Otherwise, the current view will call its "AnimateOutAsCurrentVIew" event, 
                ///  and the previous view will call its "AnimateInAsPreviousView" event
                /// </summary>
                /// <param name="currentView">The current view.</param>
                /// <param name="previousView">The previous view.</param>
                /// <param name="pushOrPop">True: the current view is going to be shown; False: the current view is going to hidden</param>
                /// <param name="animateIn">Set to true if the view to be shown needs animation.</param>
                /// <param name="animateOut">Set to true if the view to be hiden needs animation.</param>
                /// <param name="otherAnimations">Other animations that needs to be incorporated.</param>
                /// <returns></returns>
                public static async Task CustomTransitioning(NavigatableView currentView, NavigatableView previousView, bool pushOrPop, bool animateIn, bool animateOut, Animation otherAnimations = null)
                {
                        await Task.Run(() =>
                        {
                                List<Task> tasks = new List<Task>();
                                if (pushOrPop)
                                {
                                        // Current view push in
                                        if (animateIn) tasks.Add(currentView.AnimateInAsCurrentView());
                                        if (animateOut) tasks.Add(previousView.AnimateOutAsPreviousView());
                                }
                                else
                                {
                                        // Current view push out
                                        if (animateOut) tasks.Add(currentView.AnimateOutAsCurentView());
                                        if (animateIn) tasks.Add(previousView.AnimateInAsPreviousView());
                                }
                                if (otherAnimations != null) tasks.Add(Task.Run(() => otherAnimations?.Commit(currentView, nameof(otherAnimations))));
                                if (tasks.Count > 0) Task.WaitAll(tasks.ToArray());
                        });
                }

                /// <summary>
                /// Use the default animation
                /// </summary>
                /// <param name="currentView">The current view.</param>
                /// <param name="animationBehaviour">Provide a <see cref="DefaultAnimationBehavior"/></param>
                /// <param name="AnimateIn">The current view is about to animate in or out? True: in/ False: out.</param>
                /// <param name="animation">Do the animation or not.</param>
                /// <param name="previousView">By default this is null. Provide the previous view if you want the previous view to have default animate in/out</param>
                /// <param name="otherAnimations">Other animations that need to be incorporated.</param>
                /// <param name="duration">The animation time. (in ms)</param>
                /// <returns></returns>
                public static async Task DefaultTransitioning(NavigatableView currentView, DefaultAnimationBehavior animationBehaviour, bool AnimateIn, bool animation = true, NavigatableView previousView = null, Animation otherAnimations = null, uint duration = 250)
                {
                        await Task.Run(() =>
                        {
                                Animation totalAnimtaion = new Animation();
                                Animation currentViewAnimtaion = new Animation();
                                Animation previousViewAnimation = new Animation();

                                switch (animationBehaviour)
                                {
                                        case DefaultAnimationBehavior.FadeInOut:
                                                currentViewAnimtaion = new Animation(v => currentView.Opacity = v, AnimateIn ? 0 : 1, AnimateIn ? 1 : 0, Easing.SinInOut);
                                                if (previousView != null)
                                                        previousViewAnimation = new Animation(v => previousView.Opacity = v, AnimateIn ? 1 : 0, AnimateIn ? 0 : 1, Easing.SinInOut);
                                                break;

                                        case DefaultAnimationBehavior.ScaleAndFadeInOut:
                                                currentViewAnimtaion = new Animation(v => currentView.Opacity = v, AnimateIn ? 0 : 1, AnimateIn ? 1 : 0, Easing.SinInOut);
                                                currentViewAnimtaion.Add(0, 1, new Animation(v => currentView.Scale = v, AnimateIn ? 1.2 : 1, AnimateIn ? 1 : 1.2, Easing.SinInOut));
                                                if (previousView != null)
                                                {
                                                        previousViewAnimation = new Animation(v => previousView.Opacity = v, AnimateIn ? 1 : 0, AnimateIn ? 0 : 1, Easing.SinInOut);
                                                        previousViewAnimation.Add(0, 1, new Animation(v => previousView.Opacity = v, AnimateIn ? 1 : 1.2, AnimateIn ? 1.2 : 1, Easing.SinInOut));
                                                }
                                                break;

                                        case DefaultAnimationBehavior.SlideInOutFromLeft:
                                                currentViewAnimtaion = new Animation(
                                                        v => currentView.TranslationX = v, AnimateIn ? -currentView.Width : 0, AnimateIn ? 0 : -currentView.Width, Easing.SinInOut);

                                                if (previousView != null)
                                                        previousViewAnimation = new Animation(
                                                        v => previousView.TranslationX = v, AnimateIn ? 0 : previousView.Width, AnimateIn ? previousView.Width : 0, Easing.SinInOut);
                                                break;

                                        case DefaultAnimationBehavior.SlideInOutFromRight:
                                                currentViewAnimtaion = new Animation(
                                                        v => currentView.TranslationX = v, AnimateIn ? currentView.Width : 0, AnimateIn ? 0 : currentView.Width, Easing.SinInOut);

                                                if (previousView != null)
                                                        previousViewAnimation = new Animation(
                                                        v => previousView.TranslationX = v, AnimateIn ? 0 : -previousView.Width, AnimateIn ? -previousView.Width : 0, Easing.SinInOut);
                                                break;

                                        case DefaultAnimationBehavior.SlideInOutFromTop:
                                                currentViewAnimtaion = new Animation(
                                                        v => currentView.TranslationY = v, AnimateIn ? currentView.Height : 0, AnimateIn ? 0 : currentView.Height, Easing.SinInOut);

                                                if (previousView != null)
                                                        previousViewAnimation = new Animation(
                                                        v => previousView.TranslationY = v, AnimateIn ? 0 : -previousView.Height, AnimateIn ? -previousView.Height : 0, Easing.SinInOut);
                                                break;

                                        case DefaultAnimationBehavior.SlideInOutFromBottom:
                                                currentViewAnimtaion = new Animation(
                                                        v => currentView.TranslationY = v, AnimateIn ? -currentView.Height : 0, AnimateIn ? 0 : -currentView.Height, Easing.SinInOut);

                                                if (previousView != null)
                                                        previousViewAnimation = new Animation(
                                                        v => previousView.TranslationY = v, AnimateIn ? 0 : previousView.Height, AnimateIn ? previousView.Height : 0, Easing.SinInOut);
                                                break;

                                        case DefaultAnimationBehavior.FadeAndSlideInOutFromLeft:
                                                currentViewAnimtaion = new Animation(v => currentView.Opacity = v, AnimateIn ? 0 : 1, AnimateIn ? 1 : 0, Easing.SinInOut);
                                                currentViewAnimtaion.Add(0, 1, new Animation(
                                                        v => currentView.TranslationX = v, AnimateIn ? currentView.Width : 0, AnimateIn ? 0 : currentView.Width, Easing.SinInOut));

                                                if (previousView != null)
                                                {
                                                        previousViewAnimation = new Animation(v => previousView.Opacity = v, AnimateIn ? 1 : 0, AnimateIn ? 0 : 1, Easing.SinInOut);
                                                        previousViewAnimation.Add(0, 1, new Animation(
                                                                v => previousView.TranslationX = v, AnimateIn ? 0 : -previousView.Width, AnimateIn ? -previousView.Width : 0, Easing.SinInOut));
                                                }
                                                break;

                                        case DefaultAnimationBehavior.FadeAndSlideInOutFromRight:
                                                currentViewAnimtaion = new Animation(v => currentView.Opacity = v, AnimateIn ? 0 : 1, AnimateIn ? 1 : 0, Easing.SinInOut);
                                                currentViewAnimtaion.Add(0, 1, new Animation(
                                                        v => currentView.TranslationX = v, AnimateIn ? -currentView.Width : 0, AnimateIn ? 0 : -currentView.Width, Easing.SinInOut));

                                                if (previousView != null)
                                                {
                                                        previousViewAnimation = new Animation(v => previousView.Opacity = v, AnimateIn ? 1 : 0, AnimateIn ? 0 : 1, Easing.SinInOut);
                                                        previousViewAnimation.Add(0, 1, new Animation(
                                                                v => previousView.TranslationX = v, AnimateIn ? 0 : previousView.Width, AnimateIn ? previousView.Width : 0, Easing.SinInOut));
                                                }
                                                break;

                                        case DefaultAnimationBehavior.FadeAndSlideInOutFromTop:
                                                currentViewAnimtaion = new Animation(v => currentView.Opacity = v, AnimateIn ? 0 : 1, AnimateIn ? 1 : 0, Easing.SinInOut);
                                                currentViewAnimtaion.Add(0, 1, new Animation(
                                                        v => currentView.TranslationY = v, AnimateIn ? currentView.Height : 0, AnimateIn ? 0 : currentView.Height, Easing.SinInOut));

                                                if (previousView != null)
                                                {
                                                        previousViewAnimation = new Animation(v => previousView.Opacity = v, AnimateIn ? 1 : 0, AnimateIn ? 0 : 1, Easing.SinInOut);
                                                        previousViewAnimation.Add(0, 1, new Animation(
                                                                v => previousView.TranslationY = v, AnimateIn ? 0 : -previousView.Height, AnimateIn ? -previousView.Height : 0, Easing.SinInOut));
                                                }
                                                break;

                                        case DefaultAnimationBehavior.FadeAndSlideInOutFromBottom:
                                                currentViewAnimtaion = new Animation(v => currentView.Opacity = v, AnimateIn ? 0 : 1, AnimateIn ? 1 : 0, Easing.SinInOut);
                                                currentViewAnimtaion.Add(0, 1, new Animation(
                                                        v => currentView.TranslationY = v, AnimateIn ? -currentView.Height : 0, AnimateIn ? 0 : -currentView.Height, Easing.SinInOut));

                                                if (previousView != null)
                                                {
                                                        previousViewAnimation = new Animation(v => previousView.Opacity = v, AnimateIn ? 1 : 0, AnimateIn ? 0 : 1, Easing.SinInOut);
                                                        previousViewAnimation.Add(0, 1, new Animation(
                                                                v => previousView.TranslationY = v, AnimateIn ? 0 : previousView.Height, AnimateIn ? previousView.Height : 0, Easing.SinInOut));
                                                }
                                                break;
                                }

                                if (otherAnimations != null) totalAnimtaion.Add(0, 1, otherAnimations);

                                totalAnimtaion.Add(0, 1, currentViewAnimtaion);
                                if (previousView != null) totalAnimtaion.Add(0, 1, previousViewAnimation);

                                // do the animtion
                                if (animation) totalAnimtaion.Commit(currentView, nameof(DefaultTransitioning), 16, 1000, Easing.SinInOut);
                        });
                }
        }
}
