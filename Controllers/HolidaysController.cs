using System.Collections.Generic;
using Holidays.Data;
using Holidays.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holidays.Controllers
{
    //api/holidays
    [Route("api/holidays")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidayRepo _repository;
        //Constructor
        public HolidaysController(IHolidayRepo repository)
        {
            _repository = repository;
        }

        // GET api/holidays - Returns list of holidays for current year
        [HttpGet]
        public ActionResult<IEnumerable<Holiday>> GetCurrentYearHolidays()
        {
            var holidays = _repository.GetCurrentYearHolidays();

            return Ok(holidays);
        }

        // GET api/holidays/2000 - Returns list of holidays for specified year
        [HttpGet("{year}")]
        public ActionResult<Holiday> getHolidaysByYear(int year)
        {
            var holidaysByYear = _repository.GetHolidaysByYear(year);

            return Ok(holidaysByYear);
        }
    }
}