using MvvmHelpers;

namespace ICA_Gospel_App
{
        public class MainPageViewModel : BaseViewModel
        {

                private string _backgroundMediaSource = "CloudsVideo.mp4";

                private string _splashMediaSource = "SplashPage_Final.mp4";


                public string BackgroundMediaSource
                {
                        get => _backgroundMediaSource;
                        set => SetProperty(ref _backgroundMediaSource, value);
                }

                public string SplashMediaSource
                {
                        get { return _splashMediaSource; }
                        set { _splashMediaSource = value; }
                }



        }
}
