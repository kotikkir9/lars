using Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Repository
{
    public interface ICoursesRepository
    {
        IQueryable<Course> GetCourses();
        Course GetCourse(int id);
        bool CourseExists(int id);  
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        bool Save();
    }
}