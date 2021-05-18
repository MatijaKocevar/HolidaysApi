using System.Collections.Generic;
using Holidays.Models;

namespace Holidays.Data
{
    //definition of interface
    public interface IHolidayRepo
    {
        IEnumerable<Holiday> GetCurrentYearHolidays();
        IEnumerable<Holiday> GetHolidaysByYear(string year);
    }


}