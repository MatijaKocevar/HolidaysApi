using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HolidaysApi.Models;
using HolidaysApi.Scripts;


namespace HolidaysApi.Controllers
{
    public class HolidaysController : Controller
    {
        //When the page loads this is what it does
        [HttpGet]
        public IActionResult Index()
        {
            //Console.WriteLine("You're in GET Controller");

            //get data with current year
            Holidays prazniki = FillDB.fillDB(DateTime.Now.ToString("yyyy"));

            //returns html and data
            return View(prazniki);
        }

        //When I press submit this is what happens
        [HttpPost]
        public IActionResult Index(string year)
        {
            //Console.WriteLine("You're in POST Controller");

            //get data with submited year
            Holidays prazniki = FillDB.fillDB(year);

            //returns html and data
            return View(prazniki);
        }


    }
}
