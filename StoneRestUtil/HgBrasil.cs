using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Runtime.Serialization;

namespace StoneRest.Util
{
    public static class HgBrasil
    {
        private const string Url = "https://api.hgbrasil.com/weather/?key=53d99928&format=json&city_name={0}";

        public static string getTemperature(string city)
        {
            return getValue(city, "temp");
        }

        public static bool checkValidCity(string city)
        {
            return (getValue(city, "city").Contains(city));
        }

        public static string getValue(string city,string attribute)
        {
            try
            {
                var client = new HttpClient();
                var uri = new Uri(string.Format(Url, city));
                var response = client.GetAsync(uri).Result;

                var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                var dict = jss.Deserialize<dynamic>(response.Content.ReadAsStringAsync().Result);

                return Convert.ToString(dict["results"][attribute]);
            }

            catch
            {
                return "";
            }
        }
    }
}