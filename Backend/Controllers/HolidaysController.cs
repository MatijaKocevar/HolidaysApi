using System;
using System.Collections.Generic;
using Holidays.Data;
using Holidays.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holidays.Controllers
{
    [Route("api/holidays")] //attributes
    [ApiController] //attribute
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidayRepo _repository;
        //Constructor for dependency injection
        public HolidaysController(IHolidayRepo repository)
        {
            _repository = repository;
        }

        // GET api/holidays - Returns list of holidays for current year
        [HttpGet]
        public ActionResult<IEnumerable<Holiday>> GetCurrentYearHolidays()
        {
            return Ok(_repository.GetCurrentYearHolidays());
        }

        // GET api/holidays/2000 - Returns list of holidays for specified year
        [HttpGet("{year}")]
        public ActionResult<Holiday> getHolidaysByYear(string year)
        {
            if (!Int32.TryParse(year, out int y))
            {
                return BadRequest("Not a number");
            }
            else
            if (Int32.Parse(year) < 1583)
            {
                return BadRequest("Can't get holidays before 1583. No Gregorian Calendar");
            }
            else
            {
                return Ok(_repository.GetHolidaysByYear(year));
            }
        }
    }
}