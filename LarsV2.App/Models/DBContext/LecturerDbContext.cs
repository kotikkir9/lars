using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LarsV2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LarsV2.Models.DBContext
{
    public class LecturerDbContext : DbContext
    {
        public LecturerDbContext(DbContextOptions<LecturerDbContext> options) : base(options) {  }

        public DbSet<Lecturer> Lecturers { get; set; }
    }
}
