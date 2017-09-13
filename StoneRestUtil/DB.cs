using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoneRest.Util;
using LiteDB;
using System.IO;

namespace StoneRest.Util
{
    public static class DB
    {
        //private const string DBName = "DBCities.db";
        private const string DBCities = "cities"; //Collection
        private const string DBTemperatures = "temperatures"; //Collection

        public static string CreateTestDB(string DBName)
        {
            try
            {
                string TestDBName = "in_use_" + DBName;
                File.Copy(dbConn(DBName), dbConn(TestDBName));

                return TestDBName;
            }
            catch
            {
                return null;
            }

        }

        public static void DestroyTestDB(string TestDBName)
        {
            File.Delete(dbConn(TestDBName));
        }

        static public string dbConn(string DBName)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data";
            return string.Format("{0}\\{1}", dir.Replace("\\\\","\\"), DBName);
        }

        public static List<TemperaturesDB> CityTemperatures(string DBName, string city)
        {
            try
            {
                if (CheckCityExists(DBName, city))
                {
                    List<TemperaturesDB> response = new List<TemperaturesDB>();

                    using (var db = new LiteDatabase(dbConn(DBName)))
                    {
                        var cities = db.GetCollection<TemperaturesDB>(DBTemperatures);

                        var results = cities.Find(x => x.cityName.Equals(city)).Take(30); //Limitada as últimas 30 temperaturas

                        foreach (TemperaturesDB item in results)
                        {
                            response.Add(item);
                        }
                    }

                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool CheckCityExists(string DBName, string city)
        {
            try
            {
                using (var db = new LiteDatabase(dbConn(DBName)))
                {
                    var cities = db.GetCollection<CitiesDB>(DBCities);

                    var results = cities.Count(x => x.cityName.Equals(city));

                    if (results > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return true;
            }
        }

        public static Boolean AddCity(string DBName, string city)
        {
            try
            {
                if (HgBrasil.checkValidCity(city))
                {
                    using (var db = new LiteDatabase(dbConn(DBName)))
                    {
                        var cities = db.GetCollection<CitiesDB>(DBCities);

                        CitiesDB newCity = new CitiesDB();

                        newCity.cityName = city;

                        cities.Insert(newCity);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static Boolean RemoveCity(string DBName, string city)
        {
            try
            {
                using (var db = new LiteDatabase(dbConn(DBName)))
                {
                    var cities = db.GetCollection<CitiesDB>(DBCities);

                    cities.Delete(x => x.cityName.Equals(city));

                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean AddTemperature(string DBName, string city, string _date, string value)
        {
            try
            {
                using (var db = new LiteDatabase(dbConn(DBName)))
                {
                    var temperatures = db.GetCollection<TemperaturesDB>(DBTemperatures);

                    var newTemperature = new TemperaturesDB
                    {
                        cityName = city,
                        date = _date,
                        temperature = value
                    };

                    temperatures.Insert(newTemperature);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean RemoveTemperatures(string DBName, string city)
        {
            try
            {
                using (var db = new LiteDatabase(dbConn(DBName)))
                {
                    var temperatures = db.GetCollection<TemperaturesDB>(DBTemperatures);

                    temperatures.Delete(x => x.cityName.Equals(city));
                    
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean UpdateTemperatures(string DBName)
        {
            try
            {
                bool response = true;

                List<CitiesDB> results;

                using (var db = new LiteDatabase(dbConn(DBName)))
                {
                    var cities = db.GetCollection<CitiesDB>(DBCities);

                    results = cities.FindAll().ToList<CitiesDB>();
                }

                foreach (CitiesDB City in results)
                {
                    if (!AddTemperature(DBName, City.cityName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), HgBrasil.getTemperature(City.cityName)))
                    {
                        response = false;
                    }
                }



                return response;
            }
            catch
            {
                return false;
            }
        }

        public static IEnumerable<TemperaturesDB> AllTemperatures(string DBName)
        {
            try
            {
                List<TemperaturesDB> response = new List<TemperaturesDB>();

                using (var db = new LiteDatabase(dbConn(DBName)))
                {
                    var cities = db.GetCollection<TemperaturesDB>(DBTemperatures);

                    var results = cities.FindAll()
                                  .OrderByDescending(x => x.date)
                                  .ToList<TemperaturesDB>();

                    response.AddRange(results);
                }

                return response;

            }
            catch
            {
                return null;
            }
        }
    }
}