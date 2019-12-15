using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Weather
    {
        public string Description { get; set; }
        public string Temp { get; set; }
        public string FeelsLike { get; set; }
        public string Humidity { get; set; }
        public Weather()
        {

        }
        public Weather(JToken j)
        {
            this.Description = j["weather"][0]["description"].ToString();
            this.Temp = j["main"]["temp"].ToString();
            this.FeelsLike = j["main"]["feels_like"].ToString();
            this.Humidity = j["main"]["Humidity"].ToString();
        }
    }
}
