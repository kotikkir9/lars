using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.DBContext
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options) {  }

        public DbSet<Course> Courses { get; set; }
    }
}
