using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LionsEventTracker.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Time is required.")]       
        public string Time { get; set; }
        [Required(ErrorMessage = "Venue is required.")]
        public string Venue { get; set; }

        public List<User> Users { get; set; }
    }
}
