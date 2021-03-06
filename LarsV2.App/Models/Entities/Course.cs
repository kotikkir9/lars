using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject ID is required")]
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int? LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public ICollection<CourseDateTimeOffset> CourseDates { get; set; } 
    }
}