using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
using System.Linq;

namespace LarsV2.Models.Repository
{
    public class LecturerSubjectRepository : ILecturerSubjectRepository
    {
        private readonly LecturerDbContext _context;

        public LecturerSubjectRepository(LecturerDbContext context)
        {
            _context = context;
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
    }
}
