using System;
using System.Collections.Generic;

namespace StoneRest.Models
{
    public class CityModel
    {
        //public int ID { get; set; }

        public string City { get; set; }

        public List<TemperatureModel> Temperatures { get; set; }

    }
}