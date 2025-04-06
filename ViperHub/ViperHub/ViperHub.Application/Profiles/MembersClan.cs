using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViperHub.Application.Dto.ClanMembers;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
    class MembersClan : Profile
    {
        public MembersClan() 
        {
            CreateMap<UsuarioClane, UsuariosClanesResponse>();
            CreateMap<UsuariosClanesDto ,UsuarioClane>();
            CreateMap<UsuarioClane, UsuarioClane>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
