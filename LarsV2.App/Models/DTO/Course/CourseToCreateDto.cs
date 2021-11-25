using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class CourseToCreateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? SubjectId { get; set; }
        public int? LecturerId { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Dates { get; set; }
    }
}
