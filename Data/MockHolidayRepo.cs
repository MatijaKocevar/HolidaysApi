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
            var holidays = getHolidays.getData(Int32.Parse(DateTime.Now.ToString("yyyy")));

            return holidays;
        }

        public IEnumerable<Holiday> GetHolidaysByYear(int year)
        {
            var holidays = getHolidays.getData(year);

            return holidays;
        }
    }
}