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
            CreateMap<Course, CourseWithDatesDto>()
                .ForMember(e => e.Status, opt => opt.MapFrom(src => CourseStatus(src.StartDate, src.EndDate)));

            CreateMap<Course, CourseDto>()
                .ForMember(e => e.Status, opt => opt.MapFrom(src => CourseStatus(src.StartDate, src.EndDate)));

            CreateMap<Course, CourseWithoutLecturerDto>()
                .ForMember(e => e.Status, opt => opt.MapFrom(src => CourseStatus(src.StartDate, src.EndDate)));

            CreateMap<CourseToCreateDto, Course>();
            CreateMap<CourseDateTimeOffset, CourseDateTimeOffsetsDto>();
        }

        private string CourseStatus(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var now = DateTime.Now;
            var dateToday = now - now.TimeOfDay;

            if (endDate != null && endDate < dateToday)
            {
                return "DONE";
            }

            if (startDate != null && startDate > dateToday)
            {
                return "READY";
            }

            if ((startDate != null && endDate != null) && (startDate <= dateToday && endDate >= dateToday))
            {
                return "IN PROGRESS";
            }

            return "";
        }
    }
}
