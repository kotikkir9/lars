using LarsV2.Helpers;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;

namespace LarsV2.Models.Repository
{
    public interface ICoursesRepository : IRepository
    {
        PagedList<Course> GetCourses(CourseResourceParameters parameters);
        Course GetCourse(int id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
        void ToggleDate(CourseDateTimeOffset date);
    }
}
