using AutoMapper;
using LarsV2.Models.Entities;
using LarsV2.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        [HttpGet(Name = "GetAllLecturers")]
        public ActionResult<IEnumerable<Lecturer>> GetAllLecturers()
        {
            var lecturers = _repository.GetLecturers();

            return Ok(lecturers);
        }

        [HttpGet("{lecturerId:int}", Name = "GetLecturer")]
        public ActionResult<Lecturer> GetSingleLecturer(int lecturerId)
        {
            var lecturer = _repository.GetLecturer(lecturerId);

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