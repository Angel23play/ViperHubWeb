using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Application.Dto.Comments;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
    class CommentsProfile : Profile
    {
        public CommentsProfile()
        {

            CreateMap<ComentariosForo, ComentarioForoResponse>();
            CreateMap<ComentarioForoDto, ComentariosForo>();
            CreateMap<ComentariosForo, ComentariosForo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
