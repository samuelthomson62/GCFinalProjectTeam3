using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Forcast
    {
        public string Headline { get; set; }
        public Forcast()
        {

        }
        public Forcast(JToken j)
        {
            this.Headline = j["Headline"]["Text"].ToString();
        }
    }
}
