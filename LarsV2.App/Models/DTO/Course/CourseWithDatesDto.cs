using LarsV2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class CourseWithDatesDto
    {
        public int Id { get; set; }
        public SubjectDto Subject { get; set; }
        public LecturerDto Lecturer { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public ICollection<CourseDateTimeOffsetsDto> CourseDates { get; set; }
    }
}
