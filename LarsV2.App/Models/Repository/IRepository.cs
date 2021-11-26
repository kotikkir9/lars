﻿namespace LarsV2.Models.Repository
{
    public interface IRepository
    {
        bool CourseExists(int id);
        bool LecturerExists(int id);
        bool SubjectExists(int id);
        bool Save();
    }
}
