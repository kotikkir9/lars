using LarsV2.Helpers;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Repository
{
    public interface ISubjectsRepository
    {
        PagedList<Subject> GetSubjects(SubjectResourceParameters parameters);
        Subject GetSubject(int id);
        bool SubjectExists(int id);
        void AddSubject(Subject subject);
        void UpdateSubject(Subject subject);
        void DeleteSubject(Subject subject);
        bool Save();
    }
}
