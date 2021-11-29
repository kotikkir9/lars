using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class CourseWithoutLecturerDto
    {
        public int Id { get; set; }
        public SubjectDto Subject { get; set; }
        public string Description { get; set; }
    }
}