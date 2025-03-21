using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViperHub.Application.Foro.Dto.Users;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
    class UsersProfile : Profile
    {
        public UsersProfile() 
        { 

            CreateMap<Usuario,UsuarioResponse>();
            CreateMap<UsuarioDto,Usuario>();
        }
    }
}
