using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViperHub.Application.Foro.Dto.Tournaments;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
    class TournamentsProfile : Profile
    {
        public TournamentsProfile() 
        {
            CreateMap<Torneo,TorneoResponse>();
            CreateMap<TorneoDto, Torneo>();
        }
    }
}
