using System;
using System.Collections.Generic;
using LandProyect.Models;

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
        public LandsViewModel Lands
        {
            get;
            set;
        }
        public LandViewModel Land
        {
            get;
            set;
        }
        #endregion

        #region Properties
        public List<Land> LandsList
        {
            get;
            set;
        }
        public TokenResponse Token
        {
            get;
            set;
        }
        #endregion


        #region Contructor
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if(instance == null){
                return new MainViewModel();
            }
            return instance;
        }
        #endregion

    }
}
