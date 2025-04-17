using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViperHub.Application.Dto.Clans;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
    class ClanProfile : Profile
    {
        public ClanProfile()
        {

            CreateMap<Clane, ClanesResponse>();
            CreateMap<ClanesDto, Clane>();
            CreateMap<Clane, Clane>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());


        }
    }
}
