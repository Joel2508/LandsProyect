using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LandProyect.Models;
using LandProyect.Views;
using Xamarin.Forms;

namespace LandProyect.ViewModels
{
    public class LandItemViewModel : Land
    {
        #region Command
        public ICommand SelectLandCommand
        {
            get { return new RelayCommand(SelectLand); }
        }

        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedView());
        }
        #endregion
    }
}
