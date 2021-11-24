using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject name is required")]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Education { get; set; }
        public string Description { get; set; }
        public ICollection<LecturerSubject> LecturerSubjects { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
