
namespace LandProyect.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Land
    {
        
        [JsonProperty(PropertyName = "code")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "code")]
        public List<string> topLevelDomain { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string alpha2Code { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string alpha3Code { get; set; }
        [JsonProperty(PropertyName = "code")]
        public List<string> callingCodes { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string capital { get; set; }
        [JsonProperty(PropertyName = "code")]
        public List<string> altSpellings { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string region { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string subregion { get; set; }

        [JsonProperty(PropertyName = "code")]
        public int population { get; set; }

        [JsonProperty(PropertyName = "code")]
        public List<int> latlng { get; set; }
        public string demonym { get; set; }
        public int area { get; set; }
        public double gini { get; set; }
        public List<string> timezones { get; set; }
        public List<string> borders { get; set; }
        public string nativeName { get; set; }
        public string numericCode { get; set; }
        public List<Currency> currencies { get; set; }
        public List<Language> languages { get; set; }
        public Translations translations { get; set; }
        public string flag { get; set; }
        public List<RegionalBloc> regionalBlocs { get; set; }
        public string cioc { get; set; }
    }
}
