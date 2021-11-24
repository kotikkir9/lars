using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LarsV2.Models.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly LecturerDbContext _context;

        public CoursesRepository(LecturerDbContext context)
        {
            _context = context;
        }

        public Course GetCourse(int id)
        {
            var course = _context.Courses
                .Where(e => e.Id == id)
                .Include(e => e.Subject)
                .Include(e => e.Lecturer)
                .Include(e => e.CourseDates)
                .FirstOrDefault();

            return course;
        }
    }
}
