using LarsV2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class LecturerWithSubjectsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CVPath { get; set; }
        public string ImagePath { get; set; }
        public bool IsExternal { get; set; }
        public IEnumerable<SubjectDto> Subjects { get; set; }
    }
}
