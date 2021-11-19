using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Entities
{
    public class LecturerSubject
    {
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
