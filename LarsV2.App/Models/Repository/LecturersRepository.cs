using LarsV2.Models.DBContext;
using LarsV2.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LarsV2.Models.Repository
{
    public class LecturersRepository : ILecturersRepository
    {
        private readonly LecturerDbContext _context;

        public LecturersRepository(LecturerDbContext context)
        {
            _context = context;
        }
        public IQueryable<Lecturer> GetLecturers()
        {
            return _context.Lecturers;
        }

        public Lecturer GetLecturer(int id)
        {
            return _context.Lecturers.FirstOrDefault(e => e.Id == id);
        }

        public bool LecturerExists(int id)
        {
            return _context.Lecturers.Any(l => l.Id == id);
        }

        public void AddLecturer(Lecturer lecturer)
        {
            if(lecturer == null)
            {
                throw new ArgumentNullException(nameof(lecturer));
            }

            _context.Lecturers.Add(lecturer);
        }

        public void DeleteLecturer(Lecturer lecturer)
        {
            if(lecturer != null)
            {
                _context.Lecturers.Remove(lecturer);
            }   
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            // No implementation needed
        }
    }
}