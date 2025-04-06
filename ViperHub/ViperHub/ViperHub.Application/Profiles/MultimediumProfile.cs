using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Application.Dto.Multimedium;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
    class MultimediumProfile : Profile
    {
        public MultimediumProfile() 
        {
            CreateMap<Multimedium, MultimediumResponse>();
            CreateMap<MultimediumDto, Multimedium>();
            CreateMap<Multimedium, Multimedium>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
