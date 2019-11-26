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


        public static LatLng GetLatLng(string location)
        {
            //this method uses the MapQuest API to convert a string location like "Grand Rapids, MI" to Latitude and Longitude for the Hiking API
            // this method has been tested and works -Sam <3
            
            HttpWebRequest request = WebRequest.CreateHttp($"http://www.mapquestapi.com/geocoding/v1/address?key=RAeJl9of0cOtFhtd9VtoGGI8jUAvaG4l&location={location}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APItext = rd.ReadToEnd();
            JToken t = JToken.Parse(APItext);
            LatLng l = new LatLng(t);
            return l;
        }
        public static List<Trails> GetResults(string location)
        {
            // this method runs the Hiking API and returns a list of Trails
            LatLng l = GetLatLng(location);
            HttpWebRequest request = WebRequest.CreateHttp($"https://www.hikingproject.com/data/get-trails?lat={l.Lat}&lon={l.Lng}&maxDistance=200&key=200641663-d6ba0e012de562cebaf18e1d1874a93f");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APItext = rd.ReadToEnd();
            JToken t = JToken.Parse(APItext);

            List<Trails> Result = new List<Trails>();
            List<JToken> x = t["trails"][0].ToList();
            foreach (JToken y in x)
            {
                Trails z = new Trails(y);
                Result.Add(z);
            }
            return Result;
        }
    }
}
