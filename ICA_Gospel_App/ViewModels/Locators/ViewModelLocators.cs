namespace ICA_Gospel_App.ViewModels.Locators
{
    public static class ViewModelLocators
    {

        #region Private Static View Model

        private static MainPageViewModel _mainPageVM;


        #endregion

        #region Public Static View Model

        public static MainPageViewModel MainPageViewModel = _mainPageVM ?? (_mainPageVM = new MainPageViewModel());


        #endregion



    }
}
