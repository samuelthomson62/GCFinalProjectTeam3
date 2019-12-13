using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class LatLng
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        public LatLng()
        {

        }
        public LatLng(JToken j)
        {
            this.Lat = j["results"][0]["locations"][0]["latLng"]["lat"].ToString();
            this.Lng = j["results"][0]["locations"][0]["latLng"]["lng"].ToString();
        }
    }
}
