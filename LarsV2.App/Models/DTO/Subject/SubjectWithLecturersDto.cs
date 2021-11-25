using LarsV2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class SubjectWithLecturersDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Education { get; set; }
        public string Description { get; set; }
        public IEnumerable<LecturerDto> Lecturers { get; set; }
    }
}
