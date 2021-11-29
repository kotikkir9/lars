using AutoMapper;
using LarsV2.Models.DTO;
using LarsV2.Models.Entities;
using LarsV2.Models.Repository;
using LarsV2.Models.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace LarsV2.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectController : Controller
    {
        private readonly ISubjectsRepository _repository;
        private readonly ILecturerSubjectRepository _LSRepository;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectsRepository repository, ILecturerSubjectRepository LSRepository, IMapper mapper)
        {
            _repository = repository;
            _LSRepository = LSRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetSubjects")]
        public ActionResult<IEnumerable<SubjectDto>> GetSubjects([FromQuery] SubjectResourceParameters param)
        {
            var subjects = _repository.GetSubjects(param);
            var subjectsDto = _mapper.Map<IEnumerable<SubjectDto>>(subjects);

            var paginationMetaData = new
            {
                totalCount = subjects.TotalCount,
                pageSize = subjects.PageSize,
                currentPage = subjects.CurrentPage,
                totalPages = subjects.TotalPages
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));

            var responseBody = new
            {
                metadata = paginationMetaData,
                records = subjectsDto
            };

            return Ok(responseBody);
        }    

        [HttpGet("{subjectId:int}", Name = "GetSubject")]
        public ActionResult<SubjectWithLecturersDto> GetSubject(int subjectId)
        {
            var subjectFromRepo = _repository.GetSubject(subjectId);

            if(subjectFromRepo == null)
            {
                return NotFound();
            }

            var subject = _mapper.Map<SubjectWithLecturersDto>(subjectFromRepo);

            return Ok(subject);
        }

        [HttpPost]
        public IActionResult CreateSubject(Subject subject)
        {
            _repository.AddSubject(subject);
            _repository.Save();

            return CreatedAtRoute("GetSubject", new { subjectId = subject.Id }, subject);
        }

        [HttpPut("{subjectId:int}")]
        public IActionResult UpdateSubject(int subjectId, Subject subject)
        {
            var subjectToUpdate = _repository.GetSubject(subjectId);

            if (subjectToUpdate == null)
            {
                return NotFound();
            }

            subject.Id = subjectId;
            _mapper.Map(subject, subjectToUpdate);

            _repository.UpdateSubject(subjectToUpdate);
            _repository.Save();

            return NoContent();
        }


        [HttpDelete("{subjectId:int}", Name = "DeleteSubject")]
        public IActionResult DeleteSubject(int subjectId)
        {
            var subjectToDelete = _repository.GetSubject(subjectId);

            if(subjectToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteSubject(subjectToDelete);
            _repository.Save();

            return NoContent();
        }

        [HttpPost("{subjectId:int}/lecturers")]
        public IActionResult AddLecturersToSubject(int subjectId, [FromBody]IdContainerDto lecturerIds)
        {
            if (!_repository.SubjectExists(subjectId))
            {
                return NotFound();
            }

            foreach (var id in lecturerIds.Ids)
            {
                if (!_LSRepository.ToggleLecturerSubjectRelation(id, subjectId))
                {
                    return NotFound();
                }
            }

            _repository.Save();
            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetSubjectsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT,DELETE");
            return Ok();
        }

    }
}
