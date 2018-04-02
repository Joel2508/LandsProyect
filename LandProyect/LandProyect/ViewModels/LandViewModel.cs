using System;
using LandProyect.Models;

namespace LandProyect.ViewModels
{
    public class LandViewModel
    {
        #region Properties
        public Land Land
        {
            get;
            set;
        }
        #endregion

        #region Contructor

        public LandViewModel(Land Land)
        {
            this.Land = Land;
        }

        #endregion
    }
}
