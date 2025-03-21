using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViperHub.Application.Foro.Dto.Teams;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
    class TeamProfile : Profile
    {
        public TeamProfile() 
        {
            CreateMap<EquiposTorneo, EquiposTorneoResponse>();
            CreateMap<EquiposTorneoDto, EquiposTorneo>();
        }
    }
}
    