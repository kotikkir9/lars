﻿// <auto-generated />
using System;
using LarsV2.Models.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LarsV2.Migrations
{
    [DbContext(typeof(LecturerDbContext))]
    partial class LecturerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LarsV2.Models.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LecturerId = 1,
                            SubjectId = 1
                        });
                });

            modelBuilder.Entity("LarsV2.Models.Entities.CourseDateTimeOffset", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CourseDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("CourseId", "CourseDateTime");

                    b.ToTable("CourseDataTimeOffsets");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseDateTime = new DateTimeOffset(new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0))
                        },
                        new
                        {
                            CourseId = 1,
                            CourseDateTime = new DateTimeOffset(new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("LarsV2.Models.Entities.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsExternal")
                        .HasColumnType("bit");

                    b.Property<string>("Knowledge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Lecturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jan@eamv.dk",
                            FirstName = "Jan Pan",
                            IsExternal = false,
                            LastName = "Nees",
                            PhoneNumber = "+4512345678"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jameshetfield@metallica.com",
                            FirstName = "James",
                            IsExternal = false,
                            LastName = "Hetfield",
                            PhoneNumber = "+4569696969"
                        },
                        new
                        {
                            Id = 3,
                            Email = "flemming@eamv.dk",
                            FirstName = "Flemming",
                            IsExternal = false,
                            LastName = "Efternavn",
                            PhoneNumber = "+4511111111"
                        },
                        new
                        {
                            Id = 4,
                            Email = "lindemann@eamv.dk",
                            FirstName = "Till",
                            IsExternal = false,
                            LastName = "Lindemann",
                            PhoneNumber = "+4598765432"
                        },
                        new
                        {
                            Id = 5,
                            Email = "bob@eamv.dk",
                            FirstName = "Bob",
                            IsExternal = false,
                            LastName = "Ross",
                            PhoneNumber = "+4544444444"
                        },
                        new
                        {
                            Id = 6,
                            Email = "putin@eamv.dk",
                            FirstName = "Vladimir",
                            IsExternal = false,
                            LastName = "Putin",
                            PhoneNumber = "+4555555555"
                        },
                        new
                        {
                            Id = 7,
                            Email = "trump@eamv.dk",
                            FirstName = "Donald",
                            IsExternal = false,
                            LastName = "Trump",
                            PhoneNumber = "+4566666666"
                        },
                        new
                        {
                            Id = 8,
                            Email = "joe@eamv.dk",
                            FirstName = "Joe",
                            IsExternal = false,
                            LastName = "Rogan",
                            PhoneNumber = "+4577777777"
                        },
                        new
                        {
                            Id = 9,
                            Email = "max@eamv.dk",
                            FirstName = "Max",
                            IsExternal = false,
                            LastName = "Verstappen",
                            PhoneNumber = "+4588888888"
                        },
                        new
                        {
                            Id = 10,
                            Email = "messi@eamv.dk",
                            FirstName = "Lionel",
                            IsExternal = false,
                            LastName = "Messi",
                            PhoneNumber = "+4599999999"
                        },
                        new
                        {
                            Id = 11,
                            Email = "ronaldo@eamv.dk",
                            FirstName = "Cristiano",
                            IsExternal = false,
                            LastName = "Ronaldo",
                            PhoneNumber = "+4512121212"
                        },
                        new
                        {
                            Id = 12,
                            Email = "maynard@eamv.dk",
                            FirstName = "Maynard James",
                            IsExternal = false,
                            LastName = "Keenan",
                            PhoneNumber = "+4569696969"
                        },
                        new
                        {
                            Id = 13,
                            Email = "steven@eamv.dk",
                            FirstName = "Steven",
                            IsExternal = false,
                            LastName = "Wilson",
                            PhoneNumber = "+4512341234"
                        });
                });

            modelBuilder.Entity("LarsV2.Models.Entities.LecturerSubject", b =>
                {
                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("LecturerId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("LecturerSubject");

                    b.HasData(
                        new
                        {
                            LecturerId = 1,
                            SubjectId = 1
                        },
                        new
                        {
                            LecturerId = 1,
                            SubjectId = 2
                        },
                        new
                        {
                            LecturerId = 1,
                            SubjectId = 3
                        },
                        new
                        {
                            LecturerId = 1,
                            SubjectId = 4
                        },
                        new
                        {
                            LecturerId = 1,
                            SubjectId = 5
                        },
                        new
                        {
                            LecturerId = 2,
                            SubjectId = 5
                        },
                        new
                        {
                            LecturerId = 2,
                            SubjectId = 6
                        },
                        new
                        {
                            LecturerId = 2,
                            SubjectId = 7
                        },
                        new
                        {
                            LecturerId = 3,
                            SubjectId = 8
                        },
                        new
                        {
                            LecturerId = 3,
                            SubjectId = 9
                        },
                        new
                        {
                            LecturerId = 3,
                            SubjectId = 10
                        },
                        new
                        {
                            LecturerId = 4,
                            SubjectId = 10
                        },
                        new
                        {
                            LecturerId = 4,
                            SubjectId = 11
                        },
                        new
                        {
                            LecturerId = 5,
                            SubjectId = 12
                        },
                        new
                        {
                            LecturerId = 6,
                            SubjectId = 13
                        },
                        new
                        {
                            LecturerId = 6,
                            SubjectId = 14
                        },
                        new
                        {
                            LecturerId = 6,
                            SubjectId = 15
                        },
                        new
                        {
                            LecturerId = 6,
                            SubjectId = 16
                        },
                        new
                        {
                            LecturerId = 7,
                            SubjectId = 15
                        },
                        new
                        {
                            LecturerId = 7,
                            SubjectId = 16
                        },
                        new
                        {
                            LecturerId = 7,
                            SubjectId = 17
                        },
                        new
                        {
                            LecturerId = 7,
                            SubjectId = 18
                        },
                        new
                        {
                            LecturerId = 7,
                            SubjectId = 19
                        },
                        new
                        {
                            LecturerId = 8,
                            SubjectId = 20
                        },
                        new
                        {
                            LecturerId = 8,
                            SubjectId = 21
                        },
                        new
                        {
                            LecturerId = 8,
                            SubjectId = 22
                        },
                        new
                        {
                            LecturerId = 8,
                            SubjectId = 1
                        },
                        new
                        {
                            LecturerId = 9,
                            SubjectId = 5
                        },
                        new
                        {
                            LecturerId = 9,
                            SubjectId = 8
                        },
                        new
                        {
                            LecturerId = 10,
                            SubjectId = 12
                        },
                        new
                        {
                            LecturerId = 10,
                            SubjectId = 17
                        },
                        new
                        {
                            LecturerId = 10,
                            SubjectId = 20
                        },
                        new
                        {
                            LecturerId = 11,
                            SubjectId = 1
                        },
                        new
                        {
                            LecturerId = 11,
                            SubjectId = 8
                        },
                        new
                        {
                            LecturerId = 11,
                            SubjectId = 13
                        },
                        new
                        {
                            LecturerId = 11,
                            SubjectId = 20
                        },
                        new
                        {
                            LecturerId = 11,
                            SubjectId = 22
                        },
                        new
                        {
                            LecturerId = 12,
                            SubjectId = 2
                        },
                        new
                        {
                            LecturerId = 12,
                            SubjectId = 7
                        },
                        new
                        {
                            LecturerId = 12,
                            SubjectId = 19
                        });
                });

            modelBuilder.Entity("LarsV2.Models.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Education = "Automation og drift",
                            Title = "Udvikling af automatiske styringer"
                        },
                        new
                        {
                            Id = 2,
                            Education = "Automation og drift",
                            Title = "Styring og regulering"
                        },
                        new
                        {
                            Id = 3,
                            Education = "Automation og drift",
                            Title = "Maskinteknologi industri (industri)"
                        },
                        new
                        {
                            Id = 4,
                            Education = "Automation og drift",
                            Title = "SCADA, netværk og databaser"
                        },
                        new
                        {
                            Id = 5,
                            Education = "Automation og drift",
                            Title = "Robot teknologi"
                        },
                        new
                        {
                            Id = 6,
                            Education = "Automation og drift",
                            Title = "Afgangsprojekt"
                        },
                        new
                        {
                            Id = 7,
                            Education = "AU i innovation, produkt og produktion",
                            Title = "Styring og regulering"
                        },
                        new
                        {
                            Id = 8,
                            Education = "AU i innovation, produkt og produktion",
                            Title = "Projektledelse"
                        },
                        new
                        {
                            Id = 9,
                            Education = "AU i innovation, produkt og produktion",
                            Title = "Værdikæden i praksis"
                        },
                        new
                        {
                            Id = 10,
                            Education = "AU i innovation, produkt og produktion",
                            Title = "Kvalitetsoptimering med Six Sigma"
                        },
                        new
                        {
                            Id = 11,
                            Education = "AU i innovation, produkt og produktion",
                            Title = "Produktionsiotimering"
                        },
                        new
                        {
                            Id = 12,
                            Education = "AU i innovation, produkt og produktion",
                            Title = "Innovation i praksis"
                        },
                        new
                        {
                            Id = 13,
                            Education = "AU i Energiteknologi",
                            Title = "Energikonsulent 1"
                        },
                        new
                        {
                            Id = 14,
                            Education = "AU i Energiteknologi",
                            Title = "Energikonsulent opfølgning (IDV)"
                        },
                        new
                        {
                            Id = 15,
                            Education = "AU i Energiteknologi",
                            Title = "Varmepumpe (VE)"
                        },
                        new
                        {
                            Id = 16,
                            Education = "El-installation",
                            Title = "OB1 Boliginstallationer og Teknisk beregning på kredsløb"
                        },
                        new
                        {
                            Id = 17,
                            Education = "El-installation",
                            Title = "Ob2: Bygningsinstallationer og Teknisk dokumentation"
                        },
                        new
                        {
                            Id = 18,
                            Education = "El-installation",
                            Title = "Ob3: Mindre industriinstallationer og Teknisk beregning på maskiner"
                        },
                        new
                        {
                            Id = 19,
                            Education = "El-installation",
                            Title = "Ob4: Større industriinstallationer og elforsyningsanlæg"
                        },
                        new
                        {
                            Id = 20,
                            Education = "El-installation",
                            Title = "Vf2: Bekendtgørelser og standarder"
                        },
                        new
                        {
                            Id = 21,
                            Education = "El-installation",
                            Title = "Vf1: Kvalitet, sikkerhed og miljø"
                        },
                        new
                        {
                            Id = 22,
                            Education = "El-installation",
                            Title = "Afgangsprojekt"
                        });
                });

            modelBuilder.Entity("LarsV2.Models.Entities.Course", b =>
                {
                    b.HasOne("LarsV2.Models.Entities.Lecturer", "Lecturer")
                        .WithMany("Courses")
                        .HasForeignKey("LecturerId");

                    b.HasOne("LarsV2.Models.Entities.Subject", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LarsV2.Models.Entities.CourseDateTimeOffset", b =>
                {
                    b.HasOne("LarsV2.Models.Entities.Course", "Course")
                        .WithMany("CourseDates")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LarsV2.Models.Entities.LecturerSubject", b =>
                {
                    b.HasOne("LarsV2.Models.Entities.Lecturer", "Lecturer")
                        .WithMany("LecturerSubjects")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LarsV2.Models.Entities.Subject", "Subject")
                        .WithMany("LecturerSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LarsV2.Models.Entities.Course", b =>
                {
                    b.Navigation("CourseDates");
                });

            modelBuilder.Entity("LarsV2.Models.Entities.Lecturer", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("LecturerSubjects");
                });

            modelBuilder.Entity("LarsV2.Models.Entities.Subject", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("LecturerSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
