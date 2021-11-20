using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
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

        public IEnumerable<Subject> GetSubjects()
        {
            return _context.Subjects.ToList();
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
