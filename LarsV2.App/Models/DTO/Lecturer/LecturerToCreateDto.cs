using LarsV2.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.DTO
{
    public class LecturerToCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(8)]
        public string PhoneNumber { get; set; }
        public bool IsExternal { get; set; } = false;
        public IFormFile CVFile { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
