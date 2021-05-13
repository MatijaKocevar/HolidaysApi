using System;
using System.Collections.Generic;
using Holidays.Models;
using Holidays.Scripts;

namespace Holidays.Data
{
    public class SqlHolidayRepo : IHolidayRepo
    {
        private readonly HolidayContext _context;

        public SqlHolidayRepo(HolidayContext context)
        {
            _context = context;
        }

        public IEnumerable<Holiday> GetCurrentYearHolidays()
        {

            var holidays = getHolidays.getData(Int32.Parse(DateTime.Now.ToString("yyyy")), _context);

            return holidays;
        }

        public IEnumerable<Holiday> GetHolidaysByYear(int year)
        {
            var holidays = getHolidays.getData(year, _context);

            return holidays;
        }
    }
}