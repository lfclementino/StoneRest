using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneRest.Util
{
    public class CitiesDB
    {
        [LiteDB.BsonId]
        public string cityName { get; set; }
    }
}
