using ICA_Gospel_App.Views;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ICA_Gospel_App.Extensions
{
    public static class AnimatableViewExtensions
    {
        public static Task PushViewAnyc(this AnimatableView thisView, AnimatableView view, bool animateIn = true, bool animateOut = false)
        {
            return thisView.Parent.PushViewAsync(view, animateIn, animateOut);
        }

        public static Task PopViewAsync(this AnimatableView thisView,  bool animateIn = true, bool animateOut = false)
        {
            return thisView.Parent.PopViewAsync(animateIn, animateOut);
        }
    }
}
