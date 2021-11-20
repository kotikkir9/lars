using AutoMapper;
using LarsV2.Models.DTO;
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
    [Route("api/subjects")]
    public class SubjectController : Controller
    {
        private readonly ISubjectsRepository _repository;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetSubjects")]
        public ActionResult<IEnumerable<SubjectDto>> GetAllSubjects()
        {
            var subjectsFromRepo = _repository.GetSubjects();
            var subjects = _mapper.Map<IEnumerable<SubjectDto>>(subjectsFromRepo);

            return Ok(subjects);
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


    }
}
