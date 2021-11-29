using LarsV2.Helpers;
using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            var collection = _context.Courses
                .Include(e => e.Subject)
                .Include(e => e.Lecturer) as IQueryable<Course>;

            if(parameters.FromDate != null)
            {
                if (DateTimeOffset.TryParse(parameters.FromDate, out var parsedDate))
                {
                    collection = collection.Where(e => e.StartDate >= parsedDate);
                }
            }

            if (parameters.ToDate != null)
            {
                if (DateTimeOffset.TryParse(parameters.ToDate, out var parsedDate))
                {
                    collection = collection.Where(e => e.EndDate <= parsedDate);
                }
            }

            if(parameters.Active != null)
            {
                var now = DateTime.Now;
                var dateToday = now - now.TimeOfDay;

                collection = (bool)parameters.Active ? 
                    collection.Where(e => e.EndDate >= dateToday) : 
                    collection.Where(e => e.StartDate < dateToday);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Education))
            {
                var education = parameters.Education.Trim();
                collection = collection.Where(e => e.Subject.Education.Contains(education));
            }

            if (!string.IsNullOrWhiteSpace(parameters.Subject))
            {
                var subject = parameters.Subject.Trim();
                collection = collection.Where(e => e.Subject.Title.Contains(subject));
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.Trim();
                searchQuery = Regex.Replace(searchQuery, @"\s+", " ");

                collection = collection.Where(e => string.Concat(e.Lecturer.FirstName + " ", e.Lecturer.LastName).Contains(searchQuery));
            }

            collection = collection.OrderBy(e => e.StartDate);

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

        public void ToggleDate(Course course, DateTimeOffset date)
        {
            if(course.CourseDates == null)
            {
                course.CourseDates = new List<CourseDateTimeOffset>();
            }

            var dateToDelete = course.CourseDates.FirstOrDefault(e => e.CourseDateTime == date);

            if(dateToDelete == null)
            {
                if(course.StartDate == null || course.StartDate > date)
                {
                    course.StartDate = date;
                }

                if(course.EndDate == null || course.EndDate < date)
                {
                    course.EndDate = date;
                }

                course.CourseDates.Add(new CourseDateTimeOffset { CourseId = course.Id, CourseDateTime = date });
            }
            else
            {
                if(course.StartDate == date)
                {
                    course.StartDate = null;
                }
                
                if(course.EndDate == date)
                {
                    course.EndDate = null;
                }

                course.CourseDates.Remove(dateToDelete);
            }
        }

        public void UpdateCourse(Course course)
        {
            if (!course.CourseDates.Any())
            {
                course.StartDate = null;
                course.EndDate = null;
                return;
            }

            foreach (var date in course.CourseDates)
            {
                if (course.StartDate == null || course.StartDate > date.CourseDateTime)
                {
                    course.StartDate = date.CourseDateTime;
                }

                if (course.EndDate == null || course.EndDate < date.CourseDateTime)
                {
                    course.EndDate = date.CourseDateTime;
                }
            }
        }
    }
}
