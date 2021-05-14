using Holidays.Models;
using Microsoft.EntityFrameworkCore;

namespace Holidays.Data
{
    public class HolidayContext : DbContext
    {
        //constructor - passing options of type HolidayContext to DBContext
        public HolidayContext(DbContextOptions<HolidayContext> opt) : base(opt)
        {

        }

        //representation of Holiday model to database
        public DbSet<Holiday> Holidays { get; set; }
    }
}