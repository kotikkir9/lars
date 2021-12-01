using LarsV2.Helpers;
using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LarsV2.Models.Repository
{
    public class LecturersRepository : Repository, ILecturersRepository
    {
        public LecturersRepository(LecturerDbContext context) : base(context)
        {

        }

        public PagedList<Lecturer> GetLecturers(LecturerResourceParameters parameters)
        {
            if(parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var collection = _context.Lecturers as IQueryable<Lecturer>;

            if (!string.IsNullOrWhiteSpace(parameters.Education) && !string.IsNullOrWhiteSpace(parameters.Subject))
            {
                var education = parameters.Education.Trim();
                var subject = parameters.Subject.Trim();
                collection = collection.Where(l => l.LecturerSubjects.Any(e => e.Subject.Education == education && e.Subject.Title == subject));
            }
            else
            {             
                if (!string.IsNullOrWhiteSpace(parameters.Education))
                {
                    var education = parameters.Education.Trim();
                    collection = collection.Where(l => l.LecturerSubjects.Any(e => e.Subject.Education == education));
                }

                if(!string.IsNullOrWhiteSpace(parameters.Subject))
                {
                    var subject = parameters.Subject.Trim();
                    collection = collection.Where(l => l.LecturerSubjects.Any(e => e.Subject.Title == subject));
                }
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.Trim();
                searchQuery = Regex.Replace(searchQuery, @"\s+", " ");

                collection = collection.Where(l => string.Concat(l.FirstName + " ", l.LastName).Contains(searchQuery) || l.Email.Contains(searchQuery) || l.PhoneNumber.Contains(searchQuery));
            }

            collection = collection.OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

            return PagedList<Lecturer>.Create(collection, parameters.PageNumber, parameters.PageSize);
        }

        public Lecturer GetLecturer(int id)
        {
            return _context.Lecturers.FirstOrDefault(e => e.Id == id);
        }

        public async Task<Lecturer> GetFullLecturer(int id)
        {
            var lecturer = await _context.Lecturers
                .Include(e => e.LecturerSubjects).ThenInclude(e => e.Subject)
                .Include(e => e.Courses).ThenInclude(e => e.Subject)
                .Where(e => e.Id == id)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
             
            return lecturer;
        }

        public void AddLecturer(Lecturer lecturer, IEnumerable<Subject> subjects)
        {
            if(lecturer == null)
            {
                throw new ArgumentNullException(nameof(lecturer));
            }

            _context.Lecturers.Add(lecturer);
            _context.SaveChanges();

            if (subjects != null)
            {
                foreach (var subject in subjects)
                {
                    if (subject.Id == 0)
                    {
                        _context.Subjects.Add(subject);
                        _context.SaveChanges();
                    }
                    
                    _context.LecturerSubject.Add(new LecturerSubject { LecturerId = lecturer.Id, SubjectId = subject.Id });
                }
                _context.SaveChanges();
            }
        }

        public void DeleteLecturer(Lecturer lecturer)
        {
            if(lecturer != null)
            {
                _context.Lecturers.Remove(lecturer);
            }   
        }

        public IEnumerable<Course> GetCoursesForLecturer(int id)
        {
            var coursesForLecturer = _context.Courses
                .Where(e => e.LecturerId == id)
                .Include(e => e.Subject)
                .Include(e => e.CourseDates);
            
            return coursesForLecturer;
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            // No implementation needed
        }  
    }
}