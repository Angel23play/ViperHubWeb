using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViperHub.Application.Dto.Themes;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{

    class ThemeProfile : Profile
    {
        public ThemeProfile()
            {
            CreateMap<TemasForo, TemasForoResponse>();
            CreateMap<TemasForoDto, TemasForo>();
            CreateMap<TemasForo, TemasForo>()
               .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
