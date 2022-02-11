using System;
using System.ComponentModel.DataAnnotations;

namespace mission6.Models
{
    public class Task
    {

        [Key]
        [Required]
        public int TaskID { get; set; }
        public string TaskName { get; set; }
       
    }
}
