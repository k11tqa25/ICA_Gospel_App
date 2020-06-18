namespace ICA_Gospel_App
{
    public static class MainPageViewModelLocator
    {
        private static MainPageViewModel _vm;

        public static MainPageViewModel MainPageViewModel = _vm ?? (_vm = new MainPageViewModel());
    }
}
