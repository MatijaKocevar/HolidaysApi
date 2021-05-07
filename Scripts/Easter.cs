using System;
using HolidaysApi.Models;

namespace HolidaysApi.Scripts
{
    public class Easter
    {
        static public HolidaysData getEaster(string input)
        {
            // Easter algorithm
            if (input == null)
                input = DateTime.Now.ToString("yyyy");

            int year = Int32.Parse(input);
            int day = 0;
            int month = 3;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            //This adds Easter date to an object and returns it
            HolidaysData Easter = new HolidaysData();
            Easter.name = "Easter Monday";
            Easter.day = day + 1;
            Easter.month = month;
            Easter.year = input;
            return Easter;
        }
    }
}
