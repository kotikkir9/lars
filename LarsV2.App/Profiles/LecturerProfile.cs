using AutoMapper;
using LarsV2.Models.Entities;
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
            CreateMap<Lecturer, Lecturer>().ForMember(l => l.Id, opt => opt.Ignore());
        }     
    }
}
