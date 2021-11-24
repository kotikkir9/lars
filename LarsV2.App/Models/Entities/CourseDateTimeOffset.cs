using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Entities
{
    public class CourseDateTimeOffset
    {
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Required]
        public DateTimeOffset CourseDateTime { get; set; }
    }
}
