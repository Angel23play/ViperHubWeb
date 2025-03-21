using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViperHub.Application.Foro.Dto.Themes;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{

    class ThemeProfile : Profile
    {
        public ThemeProfile()
        {
            CreateMap<TemasForo, TemasForoResponse>();
            CreateMap<TemasForoDto, TemasForo>();
        }
    }
}
