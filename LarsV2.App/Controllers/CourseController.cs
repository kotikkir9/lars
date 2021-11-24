using LarsV2.Models.Entities;
using LarsV2.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : Controller
    {
        private readonly ICoursesRepository _repository;

        public CourseController(ICoursesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{courseId:int}")]
        public ActionResult<Course> GetCourse(int courseId)
        {
            return _repository.GetCourse(courseId);
        }


    }
}
