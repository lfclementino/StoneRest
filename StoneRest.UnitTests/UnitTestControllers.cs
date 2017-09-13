using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoneRest.Controllers;
using StoneRest.Models;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Web.Http;
using StoneRest.Util;
using System.Web;
using System.Web.Mvc;

namespace StoneRest.UnitTests
{
    [TestClass]
    public class CitiesControllerUnitTests
    {
        private string TestDBName = "DBCities_ForTests.db";

        [TestMethod]
        public void TemperaturesGetMethod()
        {
            string in_use = DB.CreateTestDB(TestDBName);

            var citiesController = new CitiesController(in_use)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
                
            };
            
            HttpResponseMessage result = citiesController.Get("Rio de Janeiro");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            DB.DestroyTestDB(in_use);
        }

        [TestMethod]
        public void AddCityByCEPMethod()
        {
            string in_use = DB.CreateTestDB(TestDBName);

            var citiesController = new CitiesController(in_use)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()

            };

            HttpResponseMessage result = citiesController.AddCityByCEP("69005180"); // Manaus

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            DB.DestroyTestDB(in_use);
        }

        [TestMethod]
        public void AddCityMethod()
        {
            string in_use = DB.CreateTestDB(TestDBName);

            var citiesController = new CitiesController(in_use)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()

            };

            HttpResponseMessage result = citiesController.Post("Petropolis");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            DB.DestroyTestDB(in_use);
        }

        [TestMethod]
        public void DeleteCityMethod()
        {
            string in_use = DB.CreateTestDB(TestDBName);

            var citiesController = new CitiesController(in_use)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()

            };

            HttpResponseMessage result = citiesController.Delete("Rio de Janeiro");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            DB.DestroyTestDB(in_use);
        }

        [TestMethod]
        public void DeleteCityTemperaturesMethod()
        {
            string in_use = DB.CreateTestDB(TestDBName);

            var citiesController = new CitiesController(in_use)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()

            };

            HttpResponseMessage result = citiesController.DeleteTemperatures("Rio de Janeiro");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            DB.DestroyTestDB(in_use);
        }

        [TestMethod]
        public void GetListMethod()
        {
            string in_use = DB.CreateTestDB(TestDBName);

            var temperaturesController = new TemperaturesController(in_use);

            var result = temperaturesController.Index() as ViewResult; 
            
            Assert.AreEqual(((ListModel)result.Model).CurrentPageIndex, 1);

            DB.DestroyTestDB(in_use);
        }

        private CityModel GetTestCity()
        {
            var TemperatureResponse = new List<TemperatureModel>();
            TemperatureResponse.Add(new TemperatureModel { Date = "2017-09-12 21:25:27", Temperature = "22" });
            TemperatureResponse.Add(new TemperatureModel { Date = "2017-09-12 22:37:57", Temperature = "22" });

            return new CityModel { City = "Rio de Janeiro", Temperatures = TemperatureResponse };
        }
    }
}
