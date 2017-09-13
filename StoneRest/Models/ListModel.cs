using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoneRest.Util;

namespace StoneRest.Models
{
    public class ListModel
    {
        public IEnumerable<TemperaturesDB> Temperatures { get; set; }

        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }
    }
}