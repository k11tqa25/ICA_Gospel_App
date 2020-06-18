using MvvmHelpers;

namespace ICA_Gospel_App
{
    public class MainPageViewModel: BaseViewModel
    {

        private string _backgroundMediaSource = "CloudsVideo.mp4";

        public string BackgroundMediaSource
        {
            get => _backgroundMediaSource;
            set => SetProperty(ref _backgroundMediaSource, value);
        } 
    }
}
