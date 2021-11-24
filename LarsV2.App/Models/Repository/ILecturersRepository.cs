using LarsV2.Helpers;
using LarsV2.Models.DTO;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Repository
{
    public interface ILecturersRepository
    {
        PagedList<Lecturer> GetLecturers(LecturerResourceParameters parameters);
        Lecturer GetLecturer(int id);
        bool LecturerExists(int id);  
        void AddLecturer(Lecturer lecturer);
        void UpdateLecturer(Lecturer lecturer);
        void DeleteLecturer(Lecturer lecturer);
        bool Save();
    }
}