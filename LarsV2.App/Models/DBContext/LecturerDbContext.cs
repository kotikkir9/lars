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
        public DbSet<LecturerSubject> LecturerSubject { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDateTimeOffset> CourseDataTimeOffsets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LecturerSubject>().HasKey(ls => new { ls.LecturerId, ls.SubjectId });
            modelBuilder.Entity<LecturerSubject>()
                .HasOne(ls => ls.Lecturer)
                .WithMany(l => l.LecturerSubjects)
                .HasForeignKey(ls => ls.LecturerId);

            modelBuilder.Entity<LecturerSubject>()
                .HasOne(ls => ls.Subject)
                .WithMany(s => s.LecturerSubjects)
                .HasForeignKey(ls => ls.SubjectId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Subject)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.SubjectId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Lecturer)
                .WithMany(l => l.Courses)
                .HasForeignKey(c => c.LecturerId)
                .IsRequired(false);

            modelBuilder.Entity<CourseDateTimeOffset>()
                .HasOne(d => d.Course)
                .WithMany(c => c.CourseDates)
                .HasForeignKey(d => d.CourseId);

            modelBuilder.Entity<CourseDateTimeOffset>().HasKey(d => new { d.CourseId, d.CourseDateTime });
              

            var subjectList = new List<Subject>()
            {
                new Subject()
                {
                    Id = 1,
                    Title = "Udvikling af automatiske styringer",
                    Education = "Automation og drift"
                },
                new Subject()
                {
                    Id = 2,
                    Title = "Styring og regulering",
                    Education = "Automation og drift"
                },
                new Subject()
                {
                    Id = 3,
                    Title = "Maskinteknologi industri (industri)",
                    Education = "Automation og drift"
                },
                new Subject()
                {
                    Id = 4,
                    Title = "SCADA, netværk og databaser",
                    Education = "Automation og drift"
                },
                new Subject()
                {
                    Id = 5,
                    Title = "Robot teknologi",
                    Education = "Automation og drift"
                },
                new Subject()
                {
                    Id = 6,
                    Title = "Afgangsprojekt",
                    Education = "Automation og drift"
                },
                new Subject()
                {
                    Id = 7,
                    Title = "Styring og regulering",
                    Education = "AU i innovation, produkt og produktion"
                },
                new Subject()
                {
                    Id = 8,
                    Title = "Projektledelse",
                    Education = "AU i innovation, produkt og produktion"
                },
                new Subject()
                {
                    Id = 9,
                    Title = "Værdikæden i praksis",
                    Education = "AU i innovation, produkt og produktion"
                },
                new Subject()
                {
                    Id = 10,
                    Title = "Kvalitetsoptimering med Six Sigma",
                    Education = "AU i innovation, produkt og produktion"
                },
                new Subject()
                {
                    Id = 11,
                    Title = "Produktionsiotimering",
                    Education = "AU i innovation, produkt og produktion"
                },
                new Subject()
                {
                    Id = 12,
                    Title = "Innovation i praksis",
                    Education = "AU i innovation, produkt og produktion"
                },
                new Subject()
                {
                    Id = 13,
                    Title = "Energikonsulent 1",
                    Education = "AU i Energiteknologi"
                },
                new Subject()
                {
                    Id = 14,
                    Title = "Energikonsulent opfølgning (IDV)",
                    Education = "AU i Energiteknologi"
                },
                new Subject()
                {
                    Id = 15,
                    Title = "Varmepumpe (VE)",
                    Education = "AU i Energiteknologi"
                },
                new Subject()
                {
                    Id = 16,
                    Title = "OB1 Boliginstallationer og Teknisk beregning på kredsløb",
                    Education = "El-installation"
                },
                new Subject()
                {
                    Id = 17,
                    Title = "Ob2: Bygningsinstallationer og Teknisk dokumentation",
                    Education = "El-installation"
                },
                new Subject()
                {
                    Id = 18,
                    Title = "Ob3: Mindre industriinstallationer og Teknisk beregning på maskiner",
                    Education = "El-installation"
                },
                new Subject()
                {
                    Id = 19,
                    Title = "Ob4: Større industriinstallationer og elforsyningsanlæg",
                    Education = "El-installation"
                },
                new Subject()
                {
                    Id = 20,
                    Title = "Vf2: Bekendtgørelser og standarder",
                    Education = "El-installation"
                },
                new Subject()
                {
                    Id = 21,
                    Title = "Vf1: Kvalitet, sikkerhed og miljø",
                    Education = "El-installation"
                },
                new Subject()
                {
                    Id = 22,
                    Title = "Afgangsprojekt",
                    Education = "El-installation"
                }
            };

            var lecturerList = new List<Lecturer>()
            {
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
            };

            var lecturerSubjectList = new List<LecturerSubject>()
            {
                new LecturerSubject
                {
                    LecturerId = 1,
                    SubjectId = 1
                },
                new LecturerSubject
                {
                    LecturerId = 1,
                    SubjectId = 2
                },
                new LecturerSubject
                {
                    LecturerId = 1,
                    SubjectId = 3
                },
                new LecturerSubject
                {
                    LecturerId = 1,
                    SubjectId = 4
                },
                new LecturerSubject
                {
                    LecturerId = 1,
                    SubjectId = 5
                },
                new LecturerSubject
                {
                    LecturerId = 2,
                    SubjectId = 5
                },
                new LecturerSubject
                {
                    LecturerId = 2,
                    SubjectId = 6
                },
                new LecturerSubject
                {
                    LecturerId = 2,
                    SubjectId = 7
                },
                new LecturerSubject
                {
                    LecturerId = 3,
                    SubjectId = 8
                },
                new LecturerSubject
                {
                    LecturerId = 3,
                    SubjectId = 9
                },
                new LecturerSubject
                {
                    LecturerId = 3,
                    SubjectId = 10
                },
                new LecturerSubject
                {
                    LecturerId = 4,
                    SubjectId = 10
                },
                new LecturerSubject
                {
                    LecturerId = 4,
                    SubjectId = 11
                },
                new LecturerSubject
                {
                    LecturerId = 5,
                    SubjectId = 12
                },
                new LecturerSubject
                {
                    LecturerId = 6,
                    SubjectId = 13
                },
                new LecturerSubject
                {
                    LecturerId = 6,
                    SubjectId = 14
                },
                new LecturerSubject
                {
                    LecturerId = 6,
                    SubjectId = 15
                },
                new LecturerSubject
                {
                    LecturerId = 6,
                    SubjectId = 16
                },
                new LecturerSubject
                {
                    LecturerId = 7,
                    SubjectId = 15
                },
                new LecturerSubject
                {
                    LecturerId = 7,
                    SubjectId = 16
                },
                new LecturerSubject
                {
                    LecturerId = 7,
                    SubjectId = 17
                },
                new LecturerSubject
                {
                    LecturerId = 7,
                    SubjectId = 18
                },
                new LecturerSubject
                {
                    LecturerId = 7,
                    SubjectId = 19
                },
                new LecturerSubject
                {
                    LecturerId = 8,
                    SubjectId = 20
                },
                new LecturerSubject
                {
                    LecturerId = 8,
                    SubjectId = 21
                },
                new LecturerSubject
                {
                    LecturerId = 8,
                    SubjectId = 22
                },
                new LecturerSubject
                {
                    LecturerId = 8,
                    SubjectId = 1
                },
                new LecturerSubject
                {
                    LecturerId = 9,
                    SubjectId = 5
                },
                new LecturerSubject
                {
                    LecturerId = 9,
                    SubjectId = 8
                },
                new LecturerSubject
                {
                    LecturerId = 10,
                    SubjectId = 12
                },
                new LecturerSubject
                {
                    LecturerId = 10,
                    SubjectId = 17
                },
                new LecturerSubject
                {
                    LecturerId = 10,
                    SubjectId = 20
                },
                new LecturerSubject
                {
                    LecturerId = 11,
                    SubjectId = 1
                },
                new LecturerSubject
                {
                    LecturerId = 11,
                    SubjectId = 8
                },
                new LecturerSubject
                {
                    LecturerId = 11,
                    SubjectId = 13
                },
                new LecturerSubject
                {
                    LecturerId = 11,
                    SubjectId = 20
                },
                new LecturerSubject
                {
                    LecturerId = 11,
                    SubjectId = 22
                },
                new LecturerSubject
                {
                    LecturerId = 12,
                    SubjectId = 2
                },
                new LecturerSubject
                {
                    LecturerId = 12,
                    SubjectId = 7
                },
                new LecturerSubject
                {
                    LecturerId = 12,
                    SubjectId = 19
                }
            };

            var courseList = new List<Course>()
            {
                new Course
                {
                    Id = 1,
                    SubjectId = 1,
                    LecturerId = 1
                }
            };

            var courseDatesList = new List<CourseDateTimeOffset>()
            {
                new CourseDateTimeOffset
                {
                    CourseId = 1,
                    CourseDateTime = DateTimeOffset.Parse("24/12/2021")
                },
                new CourseDateTimeOffset
                {
                    CourseId = 1,
                    CourseDateTime = DateTimeOffset.Parse("31/12/2021")
                },
                new CourseDateTimeOffset
                {
                    CourseId = 1,
                    CourseDateTime = DateTimeOffset.Parse("27/12/2021")
                },
                new CourseDateTimeOffset
                {
                    CourseId = 1,
                    CourseDateTime = DateTimeOffset.Parse("1/12/2021")
                }
            };

            modelBuilder.Entity<Subject>().HasData(subjectList);
            modelBuilder.Entity<Lecturer>().HasData(lecturerList);
            modelBuilder.Entity<LecturerSubject>().HasData(lecturerSubjectList);
            modelBuilder.Entity<Course>().HasData(courseList);
            modelBuilder.Entity<CourseDateTimeOffset>().HasData(courseDatesList);

            base.OnModelCreating(modelBuilder);
        }
    }
}
