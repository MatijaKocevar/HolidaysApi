using System.ComponentModel.DataAnnotations;

namespace Holidays.Models
{
    public class Holiday
    {
        //Class for mapping database
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int day { get; set; }
        [Required]
        public int month { get; set; }
        [Required]
        public int year { get; set; }
        public string weekday { get; set; }
    }

}