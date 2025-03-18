using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViperHub.Application.Foro.Dto;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
    class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoriasForo, CategoriaForoDto>().ForMember(CategoriasForo dest );
        }
    }
}
