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
                },
                new Lecturer()
                {
                    Id = 4,
                    FirstName = "Till",
                    LastName = "Lindemann",
                    Email = "lindemann@eamv.dk",
                    PhoneNumber = "+4598765432"
                },
                new Lecturer()
                {
                    Id = 5,
                    FirstName = "Bob",
                    LastName = "Ross",
                    Email = "bob@eamv.dk",
                    PhoneNumber = "+4544444444"
                },
                new Lecturer()
                {
                    Id = 6,
                    FirstName = "Vladimir",
                    LastName = "Putin",
                    Email = "putin@eamv.dk",
                    PhoneNumber = "+4555555555"
                },
                new Lecturer()
                {
                    Id = 7,
                    FirstName = "Donald",
                    LastName = "Trump",
                    Email = "trump@eamv.dk",
                    PhoneNumber = "+4566666666"
                },
                new Lecturer()
                {
                    Id = 8,
                    FirstName = "Joe",
                    LastName = "Rogan",
                    Email = "joe@eamv.dk",
                    PhoneNumber = "+4577777777"
                },
                new Lecturer()
                {
                    Id = 9,
                    FirstName = "Max",
                    LastName = "Verstappen",
                    Email = "max@eamv.dk",
                    PhoneNumber = "+4588888888"
                },
                new Lecturer()
                {
                    Id = 10,
                    FirstName = "Lionel",
                    LastName = "Messi",
                    Email = "messi@eamv.dk",
                    PhoneNumber = "+4599999999"
                },
                new Lecturer()
                {
                    Id = 11,
                    FirstName = "Cristiano",
                    LastName = "Ronaldo",
                    Email = "ronaldo@eamv.dk",
                    PhoneNumber = "+4512121212"
                },
                new Lecturer()
                {
                    Id = 12,
                    FirstName = "Maynard James",
                    LastName = "Keenan",
                    Email = "maynard@eamv.dk",
                    PhoneNumber = "+4569696969"
                },
                new Lecturer()
                {
                    Id = 13,
                    FirstName = "Steven",
                    LastName = "Wilson",
                    Email = "steven@eamv.dk",
                    PhoneNumber = "+4512341234"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
