using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8GroupAssignment.Models
{
    public class TaskApplication
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        [Required(ErrorMessage="Hey I need to know your Task Bro")]
        public string Task { get; set; }
        public string Duedate { get; set; }
        [Required]
        public int Quadrant { get; set; }

        public bool Completed { get; set; }
        // Build Forieng Key relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
