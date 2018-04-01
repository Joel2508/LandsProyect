using System;
namespace LandProyect.ViewModels
{
    public class MainViewModel
    {
        #region ViewModel
        public LoginViewModel Login
        {
            get;
            set;
        }
        #endregion

        #region Contructor
        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
        #endregion

    }
}
