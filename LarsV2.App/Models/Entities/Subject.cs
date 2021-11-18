using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Education Education { get; set; }
    }
}
