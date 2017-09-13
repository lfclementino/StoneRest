using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StoneRest.Models;
using StoneRest.Util;

namespace StoneRest.Controllers
{
    public class CitiesController : ApiController
    {
        private string DB_Name;

        public CitiesController()
        {
            DB_Name = "DBCities.db";
        }

        public CitiesController(string DBName)
        {
            DB_Name = DBName;
        }

        // GET: api/Cities/5
        [Route("api/cities/{city}/temperatures")]
        [HttpGet]
        [ActionName("ShowTemperatures")]
        public HttpResponseMessage Get(string city)
        {
            List<TemperaturesDB> temperatures = DB.CityTemperatures(DB_Name, city);

            if (temperatures != null)
            {
                List<TemperatureModel> TemperatureResponse = new List<TemperatureModel>();

                foreach (TemperaturesDB temperature in temperatures)
                {
                    TemperatureResponse.Add(new TemperatureModel { Date = temperature.date, Temperature = temperature.temperature });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new CityModel { City = city, Temperatures = TemperatureResponse });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, " City not found.");
            }
        }

        [Route("api/cities/by_cep/{cep}")]
        [HttpPost]
        [ActionName("AddCityByCEP")]
        public HttpResponseMessage AddCityByCEP(string cep)
        {
            string city = ViaCep.getCity(cep);

            return Post(city);
        }

        // POST: api/Cities
        [Route("api/cities/{city}")]
        [HttpPost]
        public HttpResponseMessage Post(string city)
        {
            if (!DB.CheckCityExists(DB_Name, city))
            {
                if (DB.AddCity(DB_Name, city))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, " City added.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, " Invalid city: " + city);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, " City already exists.");
            }

        }

        [Route("api/cities/{city}/temperatures")]
        [HttpDelete]
        [ActionName("DeleteTemperatures")]
        public HttpResponseMessage DeleteTemperatures(string city)
        {
            if (DB.CheckCityExists(DB_Name, city))
            {
                if (DB.RemoveTemperatures(DB_Name, city))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, " Temperatures deleted.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, " Internal error.");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, " City not found.");
            }
        }


        // DELETE: api/Cities/5
        [Route("api/cities/{city}")]
        [HttpDelete]
        [ActionName("DeleteCity")]
        public HttpResponseMessage Delete(string city)
        {

            if (DB.CheckCityExists(DB_Name, city))
            {
                if (DB.RemoveCity(DB_Name, city))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, " City removed.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, " Internal error.");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, " City not found.");
            }
        }
    }
}
