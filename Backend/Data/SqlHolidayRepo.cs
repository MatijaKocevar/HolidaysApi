using System;
using System.Collections.Generic;
using Holidays.Models;
using Holidays.Scripts;

namespace Holidays.Data
{

    public class SqlHolidayRepo : IHolidayRepo     //implementation of interface
    {
        private readonly HolidayContext _context;

        public SqlHolidayRepo(HolidayContext context)
        {
            _context = context;
        }

        public IEnumerable<Holiday> GetCurrentYearHolidays()
        {
            return getHolidays.getData(Int32.Parse(DateTime.Now.ToString("yyyy")), _context);
        }

        public IEnumerable<Holiday> GetHolidaysByYear(string year)
        {
            return getHolidays.getData(Int32.Parse(year), _context);
        }
    }
}