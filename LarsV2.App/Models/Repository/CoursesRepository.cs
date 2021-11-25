using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LarsV2.Helpers;
using LarsV2.Models.ResourceParameters;

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

        public PagedList<Course> GetCourses(CourseResourceParameters parameters)
        {
            if(parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var collection = _context.Courses.Include(e => e.Subject).Include(e => e.Lecturer) as IQueryable<Course>;

            return PagedList<Course>.Create(collection, parameters.PageNumber, parameters.PageSize);
        }

        public bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        public void CreateCourse(Course course)
        {
            if(course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Add(course);
        }

        public void DeleteCourse(Course course)
        {
            if (course != null)
            {
                _context.Courses.Remove(course);
            }  
        }

        public void ToggleDate(CourseDateTimeOffset date)
        {
            var courseDate = _context.CourseDataTimeOffsets.FirstOrDefault(e => e.CourseId == date.CourseId && e.CourseDateTime == date.CourseDateTime);

            if(courseDate == null)
            {
                _context.CourseDataTimeOffsets.Add(new CourseDateTimeOffset { CourseId = date.CourseId, CourseDateTime = date.CourseDateTime });
            }
            else
            {
                _context.CourseDataTimeOffsets.Remove(courseDate);
            }
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCourse(Course course)
        {
            // No implementation needed
        }
    }
}
