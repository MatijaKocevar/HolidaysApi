using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidaysApi.Models
{
    //class for a list of holiday objects
    public class Holidays
    {
        public IList<HolidaysData> holidays { get; set; }
    }
}
