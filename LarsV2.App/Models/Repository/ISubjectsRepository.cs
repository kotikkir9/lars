using LarsV2.Helpers;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;

namespace LarsV2.Models.Repository
{
    public interface ISubjectsRepository : IRepository
    {
        PagedList<Subject> GetSubjects(SubjectResourceParameters parameters);
        Subject GetSubject(int id);
        //void AddSubject(Subject subject);
        void UpdateSubject(Subject subject);
        void DeleteSubject(Subject subject);
    }
}
