using System.Threading.Tasks;

namespace ICA_Gospel_App.Interfaces
{
    public interface IViewNavigation
    {
        /// <summary>
        /// The animation used for view entering
        /// </summary>
        /// <returns></returns>
        Task AnimateIn();

        /// <summary>
        /// The enimation used for view leaving
        /// </summary>
        /// <returns></returns>
        Task AnimateOut();
    }
}
