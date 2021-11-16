using Api.Models.DBContext;
using Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Api.Models.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly CoursesDbContext _context;

        public CoursesRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public IQueryable<Course> GetCourses()
        {
            return _context.Courses;
        }
        public Course GetCourse(int id)
        {        
            return _context.Courses.AsNoTracking().FirstOrDefault(e => e.CourseId == id);
        }
        bool ICoursesRepository.CourseExists(int id)
        {
            return _context.Courses.Any(c => c.CourseId == id);
        }

        public void AddCourse(Course course)
        {
            if(course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Add(course);
        }

        public void DeleteCourse(int id)
        {
            Course course = GetCourse(id);

            if(course != null)
            {
                _context.Courses.Remove(course);
            }   
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCourse(Course course)
        {
            
        }
    }
}
