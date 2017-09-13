using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneRest.Models
{
    public class CitiesList
    {
        [LiteDB.BsonId]
        public string cityName { get; set; }
    }
}
