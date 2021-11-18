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
        public DbSet<Education> Educations { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecturer>().HasData(
                new Lecturer()
                {
                    Id = 1,
                    FirstName = "Jan Pan",
                    LastName = "Nees",
                    Email = "jan@eamv.dk",
                    PhoneNumber = "+4512345678"
                },
                new Lecturer()
                {
                    Id = 2,
                    FirstName = "James",
                    LastName = "Hetfield",
                    Email = "jameshetfield@metallica.com",
                    PhoneNumber = "+4569696969"
                },
                new Lecturer()
                {
                    Id = 3,
                    FirstName = "Flemming",
                    LastName = "Efternavn",
                    Email = "flemming@eamv.dk",
                    PhoneNumber = "+4511111111"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
