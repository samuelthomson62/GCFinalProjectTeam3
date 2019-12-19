using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Forcast
    {
        public decimal Temp { get; set; }
        public string FeelsLike { get; set; }
        public string Humidity { get; set; }
        public string Description { get; set; }
        public string Clouds { get; set; }
        public string WindSpeed { get; set; }
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }
        public Forcast()
        {

        }
        public Forcast(JToken j)
        {
            this.Temp = decimal.Parse(j["main"]["temp"].ToString());
            this.FeelsLike = j["main"]["feels_like"].ToString();
            this.Humidity = j["main"]["humidity"].ToString();
            this.Description = j["weather"][0]["description"].ToString();
            this.Clouds = j["clouds"]["all"].ToString();
            this.WindSpeed = j["wind"]["speed"].ToString();

            string daytime = j["dt_txt"].ToString();
            // daytime looks like "2019-12-15 18:00:00"
            string[] bothHalfs = daytime.Split(" ");
            string[] dateOnly = bothHalfs[0].Split("-");
            DateTime o = new DateTime(int.Parse(dateOnly[0]), int.Parse(dateOnly[1]), int.Parse(dateOnly[2]));
            this.Date = o;

            this.DayOfWeek = o.ToString("ddd");
        }
    }
}
