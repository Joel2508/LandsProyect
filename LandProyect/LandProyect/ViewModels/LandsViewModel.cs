namespace LandProyect.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using LandProyect.Models;
    using LandProyect.Services;
    using Xamarin.Forms;

    public class LandsViewModel: BaseViewModel
    {
        #region Attribute
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filter;
        private List<Land> landsList;
        #endregion

        #region Service
        private ApiService apiService;
        #endregion

        public ObservableCollection<LandItemViewModel> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        public string  Filter
        {
            get { return this.filter; }
            set 
            { 
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
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
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if(!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }


            var response = await this.apiService.GetLis<Land>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");
            if(!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            this.landsList = (List<Land>)response.Result;
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            this.IsRefreshing = false;
        }

        #region Command
        public ICommand RefreshCommand
        {
            get { return new RelayCommand(Refresh); }
        }

        private void Refresh()
        {
            LoadLands();
        }


        public ICommand SearchCommand
        {
            get { return new RelayCommand(Search); }
        }

        private void Search()
        {
            if(string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel().Where(l => l.Name.ToLower().Contains(this.filter.ToLower()) ||
                                                     l.Capital.ToLower().Contains(this.filter.ToLower())));

            }

        }
        #endregion

        #region Methods
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return this.landsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }
        #endregion

    }
}
