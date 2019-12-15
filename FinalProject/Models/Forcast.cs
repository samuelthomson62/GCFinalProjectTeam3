using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Forcast
    {
        public string CurrentTemp { get; set; }
        public string CurrentFeelsLike { get; set; }
        public string CurrentHumidity { get; set; }
        public string Description { get; set; }
        public string Clouds { get; set; }
        public string WindSpeed { get; set; }
        public Forcast()
        {

        }
        public Forcast(JToken j)
        {
            this.CurrentTemp = j["main"]["temp"].ToString();
            this.CurrentFeelsLike = j["main"]["feels_like"].ToString();
            this.CurrentHumidity = j["main"]["humidity"].ToString();
            this.Description = j["weather"][0]["description"].ToString();
            this.Clouds = j["clouds"]["all"].ToString();
            this.WindSpeed = j["wind"]["speed"].ToString();
        }
    }
}
