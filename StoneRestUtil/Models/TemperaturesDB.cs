using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneRest.Util
{
    public class TemperaturesDB
    {
        public int Id { get; set; }

        public string cityName { get; set; }

        public string date { get; set; }

        public string temperature { get; set; }
    }
}