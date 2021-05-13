using System;
using System.Collections.Generic;
using Holidays.Models;
using Holidays.Data;
using System.Linq;

namespace Holidays.Scripts
{
    public class getHolidays
    {
        public static IEnumerable<Holiday> getData(int year, HolidayContext context)
        {
            var holidays = context.Holidays.ToList();

            //easter algorithm
            int day = 0;
            int month = 3;
            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int u = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = u - ((year + (int)(year / 4) + u + 2 - c + (int)(c / 4)) % 7) + 28;

            if (day > 31)
            {
                month++;
                day -= 31;
            }
            //

            holidays[3].day = day + 1;
            holidays[3].month = month;

            for (int i = 0; i < holidays.Count; i++)
            {
                holidays[i].year = year;
                DateTime dateValue = new DateTime(holidays[i].year, holidays[i].month, holidays[i].day);
                holidays[i].weekday = dateValue.ToString("dddd");
            }

            return holidays;
        }
    }

}