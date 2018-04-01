namespace LandProyect.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using LandProyect.Models;
    using LandProyect.Services;
    using Xamarin.Forms;

    public class LandsViewModel: BaseViewModel
    {
        #region Attribute
        private ObservableCollection<Land> lands;
        #endregion

        #region Service
        private ApiService apiService;
        #endregion

        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }

        #region Constructors
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        private async void LoadLands()
        {
            var response = await this.apiService.GetLis<Land>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");
            if(!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
        }
    }
}
