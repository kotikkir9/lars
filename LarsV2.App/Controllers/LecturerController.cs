using AutoMapper;
using LarsV2.Helpers;
using LarsV2.Models.DTO;
using LarsV2.Models.Entities;
using LarsV2.Models.Repository;
using LarsV2.Models.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public LecturerController(ILecturersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetLecturers")]
        public ActionResult<PagedList<Lecturer>> GetLecturers([FromQuery]LecturerResourceParameters param)
        {
            var lecturers = _repository.GetLecturers(param);

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
                records = lecturers
            };

            return Ok(responseBody);
        }

        [HttpGet("{lecturerId:int}", Name = "GetLecturer")]
        public ActionResult<LecturerWithSubjectsDto> GetLecturer(int lecturerId)
        {
            var lecturer = _repository.GetLecturerWithSubjects(lecturerId);

            if(lecturer == null)
            {
                return NotFound();
            }
         
            return Ok(lecturer);
        }

        [HttpPost]
        public IActionResult CreateLecturer(Lecturer lecturer)
        {
            _repository.AddLecturer(lecturer);
            _repository.Save();

            return CreatedAtRoute("GetLecturer", new { lecturerId = lecturer.Id }, lecturer);
        }

        [HttpPut("{lecturerId:int}")]
        public IActionResult UpdateLecturer(int lecturerId, Lecturer lecturer)
        {
            var lecturerToUpdate = _repository.GetLecturer(lecturerId);

            if(lecturerToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(lecturer, lecturerToUpdate);
            
            _repository.UpdateLecturer(lecturerToUpdate);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{lecturerId:int}", Name = "DeleteLecturer")]
        public IActionResult DeleteLecturer(int lecturerId)
        {
            var lecturerToDelete = _repository.GetLecturer(lecturerId);

            if(lecturerToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteLecturer(lecturerToDelete);
            _repository.Save();

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetLecturersOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT,DELETE");
            return Ok();
        }

    }
}