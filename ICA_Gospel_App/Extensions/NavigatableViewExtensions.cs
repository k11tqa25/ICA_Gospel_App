using ICA_Gospel_App.Views;

namespace ICA_Gospel_App
{
        public static class NavigatableViewExtensions
        {
                public static void InitializeDefaultTransitionPosition(this NavigatableView view, DefaultAnimationBehavior defaultAnimationBehavior, bool isAnimateIn = true)
                {
                        switch (defaultAnimationBehavior)
                        {
                                case DefaultAnimationBehavior.FadeInOut:
                                        view.Opacity = isAnimateIn ? view.DefaultFadeOutOpacity : 1;
                                        break;
                                case DefaultAnimationBehavior.ScaleFromSmallAndFadeInOut:
                                        view.Opacity = isAnimateIn ? view.DefaultFadeOutOpacity : 1;
                                        view.Scale = isAnimateIn ? view.DefaultScaleFromSmallerRatio : 1;
                                        break;
                                case DefaultAnimationBehavior.ScaleFromLargeAndFadeInOut:
                                        view.Opacity = isAnimateIn ? view.DefaultFadeOutOpacity : 1;
                                        view.Scale = isAnimateIn ? view.DefaultScaleFromLargerRatio : 1;
                                        break;
                                case DefaultAnimationBehavior.SlideInOutFromLeft:
                                        view.TranslationX = isAnimateIn ? -view.Width : 0;
                                        break;
                                case DefaultAnimationBehavior.SlideInOutFromRight:
                                        view.TranslationX = isAnimateIn ? view.Width : 0;
                                        break;
                                case DefaultAnimationBehavior.SlideInOutFromTop:
                                        view.TranslationY = isAnimateIn ? -view.Height : 0;
                                        break;
                                case DefaultAnimationBehavior.SlideInOutFromBottom:
                                        view.TranslationY = isAnimateIn ? view.Height : 0;
                                        break;
                                case DefaultAnimationBehavior.FadeAndSlideInOutFromLeft:
                                        view.Opacity = isAnimateIn ? view.DefaultFadeOutOpacity : 1;
                                        view.TranslationX = isAnimateIn ? -view.Width : 0;
                                        break;
                                case DefaultAnimationBehavior.FadeAndSlideInOutFromRight:
                                        view.Opacity = isAnimateIn ? view.DefaultFadeOutOpacity : 1;
                                        view.TranslationX = isAnimateIn ? view.Width : 0;
                                        break;
                                case DefaultAnimationBehavior.FadeAndSlideInOutFromTop:
                                        view.Opacity = isAnimateIn ? view.DefaultFadeOutOpacity : 1;
                                        view.TranslationY = isAnimateIn ? -view.Height : 0;
                                        break;
                                case DefaultAnimationBehavior.FadeAndSlideInOutFromBottom:
                                        view.Opacity = isAnimateIn ? view.DefaultFadeOutOpacity : 1;
                                        view.TranslationY = isAnimateIn ? view.Height : 0;
                                        break;
                        }
                }
        }
}
