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
        private readonly MockHolidayRepo _repository = new MockHolidayRepo();
        // GET api/holidays
        [HttpGet]
        public ActionResult<IEnumerable<Holiday>> GetCurrentYearHolidays()
        {
            var holidayItems = _repository.GetCurrentYearHolidays();

            return Ok(holidayItems);
        }

        // GET api/holidays/2000
        [HttpGet("{year}")]
        public ActionResult<Holiday> getHolidaysByYear(int year)
        {
            var holidaysByYear = _repository.GetHolidaysByYear(year);

            return Ok(holidaysByYear);
        }
    }
}