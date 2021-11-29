using AutoMapper;
using LarsV2.Models.DTO;
using LarsV2.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Profiles
{
    public class LecturerProfile : Profile
    {
        public LecturerProfile()
        {
            CreateMap<Lecturer, Lecturer>();

            CreateMap<LecturerToCreateDto, Lecturer>().ReverseMap();

            CreateMap<Lecturer, LecturerDto>()
                .ForMember(l => l.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Lecturer, LecturerWithSubjectsDto>()
                .ForMember(l => l.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(l => l.Subjects, opt => opt.MapFrom(src => src.LecturerSubjects.Select(x => x.Subject)));

        }     
    }
}
