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
    public interface ICoursesRepository
    {
        PagedList<Course> GetCourses(CourseResourceParameters parameters);
        Course GetCourse(int id);
        bool CourseExists(int id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
        void ToggleDate(CourseDateTimeOffset date);
        bool Save();
    }
}
