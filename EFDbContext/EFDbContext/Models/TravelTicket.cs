using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFDbContext.Models
{
    public class TravelTicket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Cost should be greater than 0")]
        public string Cost { get; set; }
    }
}
