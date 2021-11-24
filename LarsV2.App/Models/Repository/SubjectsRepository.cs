using LarsV2.Helpers;
using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Repository
{
    public class SubjectsRepository : ISubjectsRepository
    {
        private readonly LecturerDbContext _context;

        public SubjectsRepository(LecturerDbContext context)
        {
            _context = context;
        }

        public PagedList<Subject> GetSubjects(SubjectResourceParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var collection = _context.Subjects as IQueryable<Subject>;

            if(!string.IsNullOrWhiteSpace(parameters.Education))
            {
                var education = parameters.Education.Trim();
                collection = collection.Where(s => s.Education == education);
            }

            if(!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.Trim();
                collection = collection.Where(s => s.Title.Contains(searchQuery) || s.Education.Contains(searchQuery));
            }

            collection = collection.OrderBy(s => s.Education).ThenBy(s => s.Title);

            return PagedList<Subject>.Create(collection, parameters.PageNumber, parameters.PageSize);
        }

        public Subject GetSubject(int id)
        {
            var subject = _context.Subjects
                .Where(s => s.Id == id)
                .Include(s => s.LecturerSubjects)
                .ThenInclude(s => s.Lecturer)
                .FirstOrDefault();

            return subject;
        }

        public bool SubjectExists(int id)
        {
            return _context.Subjects.Any(s => s.Id == id);
        }
        
        public void AddSubject(Subject subject)
        {
            if(subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            _context.Subjects.Add(subject);
        }

        public void DeleteSubject(Subject subject)
        {
            if(subject != null)
            {
                _context.Subjects.Remove(subject);
            }
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSubject(Subject subject)
        {
            // No implementation needed
        }
    }
}
