using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class EducationDto
    {
        public string EducationTitle { get; set; }
        public List<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();

    }
}
