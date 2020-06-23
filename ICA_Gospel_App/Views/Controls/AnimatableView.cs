using ICA_Gospel_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICA_Gospel_App.Views
{
    public class AnimatableView : ContentView, IViewNavigation
    {
        /// <summary>
        /// The parent view container for this view
        /// This is used to manage the switching between views
        /// </summary>
        public INavigationManager Parent { get; set; }

        public AnimatableView()
        {
        }

        public virtual Task AnimateIn()
        {
            return null;
        }

        public virtual Task AnimateOut()
        {
            throw null;
        }
    }
}