namespace LarsV2.Models.Repository
{
    public interface ILecturerSubjectRepository
    {
        bool ToggleLecturerSubjectRelation(int lecturerId, int subjectID);
    }
}
