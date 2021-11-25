using AutoMapper;
using LarsV2.Models.DTO;
using LarsV2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseWithDatesDto>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseToCreateDto, Course>();
            CreateMap<CourseDateTimeOffset, CourseDateTimeOffsetsDto>(); 
        }
    }
}
