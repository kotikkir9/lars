using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
using System;
using System.Linq;

namespace LarsV2.Models.Repository
{
    public class Repository : IRepository
    {
        protected readonly LecturerDbContext _context;

        public Repository(LecturerDbContext context)
        {
            _context = context;
        }

        public bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        public bool LecturerExists(int id)
        {
            return _context.Lecturers.Any(e => e.Id == id);
        }

        public bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }

        public bool ToggleLecturerSubjectRelation(int lecturerId, int subjectId)
        {
            var lecturerSubject = _context.LecturerSubject.FirstOrDefault(e => e.LecturerId == lecturerId && e.SubjectId == subjectId);

            if (lecturerSubject == null)
            {
                if (_context.Subjects.Any(e => e.Id == subjectId) && _context.Lecturers.Any(e => e.Id == lecturerId))
                {
                    _context.LecturerSubject.Add(new LecturerSubject { LecturerId = lecturerId, SubjectId = subjectId });
                    return true;
                }
                return false;
            }
            else
            {
                _context.LecturerSubject.Remove(lecturerSubject);
                return true;
            }
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
