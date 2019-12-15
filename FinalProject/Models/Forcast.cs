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
        public Forcast()
        {

        }
        public Forcast(JToken j)
        {
            this.CurrentTemp = j["list"][0]["main"]["temp"].ToString();
            this.CurrentFeelsLike = j["list"][0]["main"]["feels_like"].ToString();
        }
    }
}
