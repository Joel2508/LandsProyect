using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace LandProyect.ViewModels
{
    public class LoginViewModel
    {
        #region Properties
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public bool IsRunning
        {
            get;
            set;
        }
        public bool IsRememberme
        {
            get;
            set;
        }
        #endregion


        #region Constructor
        public LoginViewModel()
        {
            this.IsRememberme = true;
        }

        #endregion

        #region Command
        public ICommand LoginCommand
        {
            get {return new  RelayCommand(Login); }
        }

        private void Login()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
