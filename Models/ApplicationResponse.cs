using System;
using System.ComponentModel.DataAnnotations;

namespace mission6.Models
{
    public class ApplicationResponse
    {

        [Key]

        [Required]

        public int ApplicationId { get; set; }

        [Required]
        public string Quadrant { get; set; }

        [Required]
        public string Task { get; set; }

        [Required]
        public string Due_Date { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]

        public string Completed { get; set; }






    }
}
