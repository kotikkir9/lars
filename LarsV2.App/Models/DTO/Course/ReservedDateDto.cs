using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class ReservedDateDto
    {
        public DateTimeOffset ReservedDate { get; set; }
        public int CourseId { get; set; }
        public SubjectDto Subject { get; set; }
    }
}
