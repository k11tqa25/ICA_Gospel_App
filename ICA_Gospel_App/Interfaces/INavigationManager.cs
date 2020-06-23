using ICA_Gospel_App.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICA_Gospel_App.Interfaces
{
    public interface INavigationManager
    {
        Task PushViewAsync(AnimatableView view, bool animateIn = true, bool animateOut = false, Animation otherAnimations = null);

        Task PopViewAsync(bool animateIn = false, bool animateOut = true);
    }
}
