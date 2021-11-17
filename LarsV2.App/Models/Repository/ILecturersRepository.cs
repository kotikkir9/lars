using LarsV2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Repository
{
    public interface ILecturersRepository
    {
        IQueryable<Lecturer> GetLecturers();
        Lecturer GetLecturer(int id);
        bool LecturerExists(int id);  
        void AddLecturer(Lecturer lecturer);
        void UpdateLecturer(Lecturer lecturer);
        void DeleteLecturer(int id);
        bool Save();
    }
}