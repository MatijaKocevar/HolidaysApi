using System;
using System.Collections.Generic;
using Holidays.Models;
using Holidays.Data;
using System.Linq;
using System.Globalization;

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
            int g = year % 19; //Golden number
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;  // Epact - number of days by which the solar year exceeds the lunar year
            int u = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11)); //Number of days from 21 March to the Paschal full moon

            day = u - ((year + (int)(year / 4) + u + 2 - c + (int)(c / 4)) % 7) + 28;  // u - number of days from 21 March to the Sunday on or before the Paschal full moon

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            //inputs easter monday date to list
            holidays[3].day = day + 1;
            holidays[3].month = month;

            //inputs Pentecost date to list
            DateTime pentecostDate = new DateTime(year, holidays[3].month, holidays[3].day).AddDays(48);
            holidays[7].day = pentecostDate.Day;
            holidays[7].month = pentecostDate.Month;

            //inputs year and weekdays to list
            for (int i = 0; i < holidays.Count; i++)
            {
                holidays[i].year = year;
                DateTime dateValue = new DateTime(holidays[i].year, holidays[i].month, holidays[i].day);
                holidays[i].weekday = dateValue.ToString("dddd", new CultureInfo("sl"));
            }

            return holidays;
        }
    }

}