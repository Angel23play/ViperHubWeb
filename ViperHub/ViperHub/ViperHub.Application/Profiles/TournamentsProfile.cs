using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViperHub.Application.Dto.Tournaments;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
    class TournamentsProfile : Profile
    {
        public TournamentsProfile() 
        {
            CreateMap<Torneo,TorneoResponse>();
            CreateMap<TorneoDto, Torneo>();
            CreateMap<Torneo, Torneo>()
               .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
