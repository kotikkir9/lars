using LarsV2.Helpers;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LarsV2.Models.Repository
{
    public interface ILecturersRepository : IRepository
    {
        PagedList<Lecturer> GetLecturers(LecturerResourceParameters parameters);
        Lecturer GetLecturer(int id);
        Task<Lecturer> GetFullLecturer(int id);
        void AddLecturer(Lecturer lecturer, IEnumerable<Subject> subjects);
        void UpdateLecturer(Lecturer lecturer);
        void DeleteLecturer(Lecturer lecturer);
        IEnumerable<Course> GetCoursesForLecturer(int id);
    }
}