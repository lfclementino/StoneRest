using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneRest.Models
{
    public class TemperaturesList
    {
        [LiteDB.BsonId]
        public string cityName { get; set; }

        public DateTime date { get; set; }

        public string temperature { get; set; }
    }
}