using AutoMapper;
using LarsV2.Helpers;
using LarsV2.Models.DTO;
using LarsV2.Models.Entities;
using LarsV2.Models.Repository;
using LarsV2.Models.ResourceParameters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/lecturers")]
    public class LecturerController : Controller
    {
        private readonly ILecturersRepository _repository;
        private readonly IMapper _mapper;
        private readonly FileHandler _fileHandler;
        private readonly string CVPath = "files/cv";

        public LecturerController(ILecturersRepository repository, IMapper mapper, IWebHostEnvironment hostEnv)
        {
            _repository = repository;
            _mapper = mapper;
            _fileHandler = new FileHandler(hostEnv);
        }


        [HttpGet(Name = "GetLecturers")]
        public ActionResult<PagedList<LecturerDto>> GetLecturers([FromQuery] LecturerResourceParameters param)
        {
            var lecturers = _repository.GetLecturers(param);
            var lecturersDto = _mapper.Map<IEnumerable<LecturerDto>>(lecturers);

            var paginationMetaData = new
            {
                totalCount = lecturers.TotalCount,
                pageSize = lecturers.PageSize,
                currentPage = lecturers.CurrentPage,
                totalPages = lecturers.TotalPages
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));

            var responseBody = new
            {
                metadata = paginationMetaData,
                records = lecturersDto
            };

            return Ok(responseBody);
        }

        [HttpGet("{lecturerId:int}", Name = "GetLecturer")]
        public async Task<ActionResult<LecturerWithSubjectsDto>> GetLecturer(int lecturerId)
        {
            var lecturerFromRepo = await _repository.GetFullLecturer(lecturerId); 

            if (lecturerFromRepo == null)
            {
                return NotFound();
            }

            var lecturer = _mapper.Map<LecturerWithSubjectsDto>(lecturerFromRepo);
            if(!string.IsNullOrEmpty(lecturer.CVPath))
            {
                lecturer.CVPath = $"http://{Request.Host}/{lecturer.CVPath}";
            }

            return Ok(lecturer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLecturer(LecturerToCreateDto lecturerDto)
        {
            var lecturer = _mapper.Map<Lecturer>(lecturerDto);
            if (lecturerDto.CVFile != null)
            {
                lecturer.CVPath = await _fileHandler.UploadDocument(lecturerDto.CVFile, CVPath);
            }

            _repository.AddLecturer(lecturer, lecturerDto.Subjects);

            return CreatedAtRoute("GetLecturer", new { lecturerId = lecturer.Id }, lecturer);
        }


        [HttpPut("{lecturerId:int}")]
        public IActionResult UpdateLecturer(int lecturerId, Lecturer lecturer)
        {
            var lecturerToUpdate = _repository.GetLecturer(lecturerId);

            if (lecturerToUpdate == null)
            {
                return NotFound();
            }

            lecturer.Id = lecturerId;
            _mapper.Map(lecturer, lecturerToUpdate);

            _repository.UpdateLecturer(lecturerToUpdate);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{lecturerId:int}", Name = "DeleteLecturer")]
        public IActionResult DeleteLecturer(int lecturerId)
        {
            var lecturerToDelete = _repository.GetLecturer(lecturerId);

            if (lecturerToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteLecturer(lecturerToDelete);
            _repository.Save();

            return NoContent();
        }

        [HttpPost("{lecturerId:int}/subjects")]
        public IActionResult AddSubjectsToLecturer(int lecturerId, [FromBody] IdContainerDto subjectIds)
        {
            if (!_repository.LecturerExists(lecturerId))
            {
                return NotFound();
            }

            foreach (var id in subjectIds.Ids)
            {
                if (!_repository.ToggleLecturerSubjectRelation(lecturerId, id))
                {
                    return NotFound();
                }
            }

            _repository.Save();
            return NoContent();
        }

        [HttpGet("{lecturerId:int}/dates")]
        public ActionResult<IEnumerable<ReservedDateDto>>CheckDatesForLecturer(int lecturerId, [FromBody]DatesToCheck datesToCheck)
        {
            var courses = _repository.GetCoursesForLecturer(lecturerId);

            var listOfTakenDates = new List<ReservedDateDto>();

            foreach (var date in datesToCheck.Dates)
            {
                DateTimeOffset parsedDate;
                if (DateTimeOffset.TryParse(date, out parsedDate))
                {
                    foreach (var course in courses)
                    {
                        if (course.CourseDates.Any(e => e.CourseDateTime == parsedDate))
                        {
                            var subjectDto = _mapper.Map<SubjectDto>(course.Subject);
                            listOfTakenDates.Add(new ReservedDateDto { CourseId = course.Id, Subject = subjectDto, ReservedDate = parsedDate });
                        }
                    }
                }
            }

            return Ok(new { ReservedDates = listOfTakenDates });
        }
        
        [HttpPut("{lecturerId}/CV")]
        public async Task<IActionResult> UploadCV(int lecturerId, [Required]IFormFile file)
        {
            var lecturer = _repository.GetLecturer(lecturerId);

            if(lecturer == null)
            {
                return NotFound();
            }

            if(lecturer.CVPath != null)
            {
                _fileHandler.DeleteFile(lecturer.CVPath);
            }

            lecturer.CVPath = await _fileHandler.UploadDocument(file, CVPath);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{lecturerId}/CV")]
        public IActionResult DeleteCV(int lecturerId)
        {
            var lecturer = _repository.GetLecturer(lecturerId);

            if(lecturer == null)
            {
                return NotFound();
            }
            
            if(lecturer.CVPath != null)
            {
                _fileHandler.DeleteFile(lecturer.CVPath);
                lecturer.CVPath = null;
            }

            _repository.Save();

            return NoContent();       
        }

    }
}