using System;
using System.Collections.Generic;
using Holidays.Models;

namespace Holidays.Scripts
{
    public class getHolidays
    {
        public static IEnumerable<Holiday> getData(int year)
        {
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

            var holidays = new List<Holiday>
            {
                new Holiday { id = 0, name = "New year", weekday = "", day = 1, month = 1, year = year },
                new Holiday { id = 1, name = "New year", weekday = "", day = 2, month = 1, year = year },
                new Holiday { id = 2, name = "Prešeren's day", weekday = "", day = 8, month = 2, year = year},
                new Holiday { id = 3, name = "Easter Monday", weekday = "", day = day+1, month = month, year = year },
                new Holiday { id = 4, name = "Day of Uprising Against Occupation", weekday = "", day = 27, month = 4, year = year },
                new Holiday { id = 5, name = "Labour Day", weekday = "", day = 1, month = 5, year = year },
                new Holiday { id = 6, name = "Labour Day", weekday = "", day = 2, month = 5, year = year },
                new Holiday { id = 7, name = "Statehood Day", weekday = "", day = 25, month = 6, year = year },
                new Holiday { id = 8, name = "Assumption of Mary", weekday = "", day = 15, month = 8, year = year },
                new Holiday { id = 9, name = "Reformation Day", weekday = "", day = 31, month = 10, year = year },
                new Holiday { id = 10, name = "All Saints' Day", weekday = "", day = 1, month = 11, year = year },
                new Holiday { id = 11, name = "Christmas Day", weekday = "", day = 25, month = 12, year = year },
                new Holiday { id = 12, name = "Independence and Unity Day", weekday = "", day = 26, month = 12, year = year }
            };

            for (int i = 0; i < holidays.Count; i++)
            {
                DateTime dateValue = new DateTime(holidays[i].year, holidays[i].month, holidays[i].day);
                holidays[i].weekday = dateValue.ToString("dddd");
            }

            return holidays;
        }
    }

}