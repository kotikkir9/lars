using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class CourseDateTimeOffsetsDto
    {
        public int CourseId { get; set; }
        public DateTimeOffset CourseDateTime { get; set; }
    }
}
