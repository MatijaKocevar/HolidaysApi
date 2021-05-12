using System;
using System.Collections.Generic;
using Holidays.Models;
using Holidays.Scripts;

namespace Holidays.Data
{
    public class MockHolidayRepo : IHolidayRepo
    {
        public IEnumerable<Holiday> GetCurrentYearHolidays()
        {
            int year = Int32.Parse(DateTime.Now.ToString("yyyy"));

            var holidays = getHolidays.getData(year);

            return holidays;
        }

        public IEnumerable<Holiday> GetHolidaysByYear(int year)
        {
            var holidays = getHolidays.getData(year);

            return holidays;
        }
    }
}