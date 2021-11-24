using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class EducationDto
    {
        public string Education { get; set; }
        public ICollection<object> Subjects { get; set; } = new List<object>();

        public EducationDto(string education)
        {
            Education = education;
        }

        public void AddSubject(int id, string subjectTitle)
        {
            Subjects.Add(new { Id = id, Subject = subjectTitle });
        }

    }
}
