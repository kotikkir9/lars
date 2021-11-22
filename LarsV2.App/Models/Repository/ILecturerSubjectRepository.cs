using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.Repository
{
    public interface ILecturerSubjectRepository
    {
        bool ToggleLecturerSubjectRelation(int lecturerId, int subjectID);
    }
}
