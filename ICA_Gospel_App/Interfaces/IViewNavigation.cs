using System.Threading.Tasks;

namespace ICA_Gospel_App
{
        public interface IViewNavigation
        {
                /// <summary>
                /// The animation used for a new view to enter 
                /// </summary>
                /// <returns></returns>
                Task AnimateInAsCurrentView();

                /// <summary>
                /// The enimation used for the current view to leave
                /// </summary>
                /// <returns></returns>
                Task AnimateOutAsCurentView();

                /// <summary>
                /// The animation used for the previous view to enter 
                /// </summary>
                /// <returns></returns>
                Task AnimateInAsPreviousView();

                /// <summary>
                /// The enimation used for the previous view to leave
                /// </summary>
                /// <returns></returns>
                Task AnimateOutAsPreviousView();
        }
}
