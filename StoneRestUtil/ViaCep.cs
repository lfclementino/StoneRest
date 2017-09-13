using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization;

namespace StoneRest.Util
{
    public static class ViaCep
    {
        private const string Url = "https://viacep.com.br/ws/{0}/json/";

        public static string getCity(string cep)
        {
            try
            {
                var client = new HttpClient();
                var uri = new Uri(string.Format(Url,cep));
                var response = client.GetAsync(uri).Result;

                var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                var dict = jss.Deserialize<dynamic>(response.Content.ReadAsStringAsync().Result);

                return Convert.ToString(dict["localidade"]);
            }

            catch
            {
                return "";
            }
        }
    }
}
