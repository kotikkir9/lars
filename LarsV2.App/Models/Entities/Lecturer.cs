using LarsV2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Entities
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CVPath { get; set; }
        public string ImagePath { get; set; }
        public bool IsExternal { get; set; } = false;
        public IEnumerable<Subject> Subjects { get; set; } = new List<Subject>();
        public string Knowledge { get; set; }
    }
}
