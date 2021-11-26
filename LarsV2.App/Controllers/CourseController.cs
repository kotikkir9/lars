using AutoMapper;
using LarsV2.Models.DTO;
using LarsV2.Models.Entities;
using LarsV2.Models.Repository;
using LarsV2.Models.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace LarsV2.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : Controller
    {
        private readonly ICoursesRepository _repository;
        private readonly IMapper _mapper;

        public CourseController(ICoursesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCourses([FromQuery]CourseResourceParameters param)
        {
            var coursesFromRepo = _repository.GetCourses(param);
            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(coursesFromRepo);

            var paginationMetaData = new
            {
                totalCount = coursesFromRepo.TotalCount,
                pageSize = coursesFromRepo.PageSize,
                currentPage = coursesFromRepo.CurrentPage,
                totalPages = coursesFromRepo.TotalPages
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));

            var responseBody = new
            {
                metadata = paginationMetaData,
                records = coursesDto
            };

            return Ok(responseBody);
        }


        [HttpGet("{courseId:int}", Name = "GetCourse")]
        public ActionResult<CourseWithDatesDto> GetCourse(int courseId)
        {
            var courseFromRepo = _repository.GetCourse(courseId);
            if(courseFromRepo == null)
            {
                return NotFound();
            }

            var courseDto = _mapper.Map<CourseWithDatesDto>(courseFromRepo);

            return Ok(courseDto);
        }

        [HttpPost]
        public IActionResult CreateCourse(CourseToCreateDto course)
        {
            if(!_repository.SubjectExists((int)course.SubjectId))
            {
                return NotFound();
            }

            if (course.LecturerId != null)
            {
                if (!_repository.LecturerExists((int)course.LecturerId))
                {
                    return NotFound();
                }
            }

            var courseToCreate = _mapper.Map<Course>(course);

            _repository.CreateCourse(courseToCreate);
            _repository.Save();

            if (course.Dates != null)
            {
                foreach (var date in course.Dates)
                {
                    DateTimeOffset parsedDate;
                    if(DateTimeOffset.TryParse(date, out parsedDate))
                    {
                        _repository.ToggleDate(new CourseDateTimeOffset{ CourseId = courseToCreate.Id, CourseDateTime = parsedDate });
                    }
                }
            }

            _repository.Save();
            return CreatedAtRoute("GetCourse", new { courseId = courseToCreate.Id }, courseToCreate);
        }

        [HttpPut("{courseId:int}")]
        public IActionResult UpdateCourse(int courseId, CourseToCreateDto course)
        {
            var courseToUpdate = _repository.GetCourse(courseId);

            if(courseToUpdate == null)
            {
                return NotFound();
            }
 
            _mapper.Map(course, courseToUpdate);

            if(course.Dates != null)
            {
                foreach(var date in course.Dates)
                {
                    DateTimeOffset parsedDate;
                    if (DateTimeOffset.TryParse(date, out parsedDate))
                    {
                        _repository.ToggleDate(new CourseDateTimeOffset { CourseId = courseId, CourseDateTime = parsedDate });
                    }
                }
            }

            _repository.UpdateCourse(courseToUpdate);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{courseId:int}")]
        public IActionResult DeleteCourse(int courseId)
        {
            var courseToDelete = _repository.GetCourse(courseId);

            if(courseToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteCourse(courseToDelete);
            _repository.Save();

            return NoContent();
        }

    }
}
