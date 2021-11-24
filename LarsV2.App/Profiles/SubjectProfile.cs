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
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, Subject>().ForMember(x => x.LecturerSubjects, ops => ops.Ignore());
            CreateMap<Subject, SubjectDto>();

            CreateMap<Subject, SubjectWithLecturersDto>()
                .ForMember(s => s.Lecturers, opt => opt.MapFrom(src => src.LecturerSubjects.Select(x => x.Lecturer)));
        }
    }
}
