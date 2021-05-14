using System.Collections.Generic;
using Holidays.Models;

//Interface
namespace Holidays.Data
{
    public interface IHolidayRepo
    {
        IEnumerable<Holiday> GetCurrentYearHolidays();
        IEnumerable<Holiday> GetHolidaysByYear(int year);
    }


}