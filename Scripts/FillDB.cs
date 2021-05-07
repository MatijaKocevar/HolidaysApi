using System;
using HolidaysApi.Models;
using Newtonsoft.Json;
using System.Net;

namespace HolidaysApi.Scripts
{
    public class FillDB
    {
    //This is a method to fill all dates, add weekdays and years to all holidays
        static public Holidays fillDB(string year)
        {
            if (year == null)
                year = DateTime.Now.ToString("yyyy");

            //parsing JSON and saving to list object
            var webClient = new WebClient();
            var filename = webClient.DownloadString(@"C:\Users\Mkocevar\source\repos\WebApplication8\Data\Holidays.json");
            Holidays prazniki = JsonConvert.DeserializeObject<Holidays>(filename);

            //get easter date and save to object
            prazniki.holidays[3] = Easter.getEaster(year);

            //add other data to object
            for (int i = 0; i < prazniki.holidays.Count; i++)
            {
                prazniki.holidays[i].year = year;

                DateTime dateValue = new DateTime(Int32.Parse(year), prazniki.holidays[i].month, prazniki.holidays[i].day);

                prazniki.holidays[i].weekday = dateValue.ToString("dddd");
            }

            return prazniki;

        }
    }
}
