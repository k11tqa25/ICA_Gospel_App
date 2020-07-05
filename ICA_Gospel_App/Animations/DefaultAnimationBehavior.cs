namespace ICA_Gospel_App
{
        public enum DefaultAnimationBehavior
        {
                /// <summary>
                /// Fade in/out the new view. 
                /// </summary>
                FadeInOut,

                /// <summary>
                /// Scale the new view from slightly smaller size to the normal size, and fade in/out from the center
                /// </summary>
                ScaleFromSmallAndFadeInOut,

                /// <summary>
                /// Scale the new view from slightly larger size to the normal size, and fade in/out from the center
                /// </summary>
                ScaleFromLargeAndFadeInOut,

                /// <summary>
                /// Slide in/Out the new view from the left.
                /// </summary>
                SlideInOutFromLeft,

                /// <summary>
                /// Slide in/Out the new view from the right.
                /// </summary>
                SlideInOutFromRight,

                /// <summary>
                /// Slide in/out the new view from the top
                /// </summary>
                SlideInOutFromTop,

                /// <summary>
                /// Slide in/out the new view from the bottom
                /// </summary>
                SlideInOutFromBottom,

                /// <summary>
                /// Fade and slide in/Out the new view from the left.
                /// </summary>
                FadeAndSlideInOutFromLeft,

                /// <summary>
                /// Fade and slide in/Out the new view from the right.
                /// </summary>
                FadeAndSlideInOutFromRight,

                /// <summary>
                /// Fade and slide in/out the new view from the top
                /// </summary>
                FadeAndSlideInOutFromTop,

                /// <summary>
                /// Fade and slide in/out the new view from the bottom
                /// </summary>
                FadeAndSlideInOutFromBottom,

                /// <summary>
                /// No animation
                /// </summary>
                None,
        }
}
