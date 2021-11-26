using LarsV2.Helpers;
using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LarsV2.Models.Repository
{
    public class CoursesRepository : Repository, ICoursesRepository
    {
        public CoursesRepository(LecturerDbContext context) : base(context)
        {
            
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

        public void UpdateCourse(Course course)
        {
            // No implementation needed
        }
    }
}
