using AutoMapper;
using LarsV2.Models.DTO;
using LarsV2.Models.Repository;
using LarsV2.Models.ResourceParameters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            ICollection<EducationDto> educationsList = new List<EducationDto>();

            var subjectsFromRepo = _subjectRepo.GetSubjects(new SubjectResourceParameters());
            var educations = subjectsFromRepo.Select(e => e.Education).Distinct().ToList();

            foreach(var education in educations)
            {
                educationsList.Add(new EducationDto(education));
            }

            foreach(var subject in subjectsFromRepo)
            {
                educationsList.Where(e => e.Education == subject.Education).FirstOrDefault()?.AddSubject(subject.Id, subject.Title);
            }

            return Ok(educationsList);
        }
    }

}