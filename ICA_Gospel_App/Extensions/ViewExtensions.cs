using Xamarin.Forms;

namespace ICA_Gospel_App.Extensions
{
    public static class ViewExtensions
    {
        /// <summary>
        /// Gets the page to which an element belongs
        /// </summary>
        /// <returns>The page.</returns>
        /// <param name="element">Element.</param>
        public static Page GetParentPage(this VisualElement element)
        {
            if (element != null)
            {
                var parent = element.Parent;
                while (parent != null)
                {
                    if (parent is Page)
                    {
                        return parent as Page;
                    }
                    parent = parent.Parent;
                }
            }
            return null;
        }


        /// <summary>
        /// Gets the view to which an element belongs
        /// </summary>
        /// <returns>The view.</returns>
        /// <param name="element">Element.</param>
        public static View GetParentView(this VisualElement element)
        {
            if (element != null)
            {
                var parent = element.Parent;
                while (parent != null)
                {
                    if (parent is View)
                    {
                        return parent as View;
                    }
                    parent = parent.Parent;
                }
            }
            return null;
        }
    }
}
