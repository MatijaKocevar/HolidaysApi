using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidaysApi.Models
{
    //Class for mapping JSON objects
    public class HolidaysData
    {
        public int id { get; set; }
        public string name { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public string year { get; set; }
        public string weekday { get; set; }

    }
}
