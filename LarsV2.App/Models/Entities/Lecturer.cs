using LarsV2.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Entities
{
    public class Lecturer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required(ErrorMessage = "PhoneNumber field is required")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public string CVPath { get; set; }
        public string ImagePath { get; set; }
        public bool IsExternal { get; set; } = false;
        public string Knowledge { get; set; }
        public ICollection<LecturerSubject> LecturerSubjects { get; set; }
    }
}
