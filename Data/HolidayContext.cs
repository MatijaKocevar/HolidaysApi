using Holidays.Models;
using Microsoft.EntityFrameworkCore;

namespace Holidays.Data
{
    public class HolidayContext : DbContext
    {
        public HolidayContext(DbContextOptions<HolidayContext> opt) : base(opt)
        {

        }

        public DbSet<Holiday> Holidays { get; set; }
    }
}