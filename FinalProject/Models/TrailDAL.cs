using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class TrailDAL
    {


        public static LatLng GetLatLon(string location)
        {
            // this method has been tested and works -Sam <3

            List<double> LatLon = new List<double>();

            HttpWebRequest request = WebRequest.CreateHttp($"http://www.mapquestapi.com/geocoding/v1/address?key=RAeJl9of0cOtFhtd9VtoGGI8jUAvaG4l&location={location}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APItext = rd.ReadToEnd();
            JToken t = JToken.Parse(APItext);
            LatLng l = new LatLng(t);
            return l;
        }

    }
}
