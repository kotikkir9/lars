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
    [Route("api/educations")]
    public class EducationController : Controller
    {
        private readonly ISubjectsRepository _subjectRepo;
        private readonly IMapper _mapper;

        public EducationController(ISubjectsRepository subjectRepo, IMapper mapper)
        {
            _subjectRepo = subjectRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEducationsWithSubjects()
        {
            var educationsDictionary = new Dictionary<string, List<object>>();
            var subjects = _subjectRepo.GetSubjects();


            var educations = _subjectRepo.GetSubjects()
                                     .Select(e => e.Education)
                                     .Distinct()
                                     .ToList();



            foreach(var education in educations)
            {
                educationsDictionary.Add(education, new List<object>());
            }

            foreach(var subject in subjects)
            {
                educationsDictionary[subject.Education].Add(new { id = subject.Id, Subject = subject.Title });
            }

            return Ok(educationsDictionary);
        }
    }
}
