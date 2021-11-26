using LarsV2.Models.DBContext;
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

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
