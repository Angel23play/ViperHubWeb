using AutoMapper;
using ViperHub.Application.Dto.Categorys;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
   public class CategoryProfile : Profile
    {
        public CategoryProfile()
         {

            CreateMap<CategoriasForo, CategoriaForoResponse>();
            CreateMap<CategoriaForoDto, CategoriasForo>();
            CreateMap<CategoriasForo, CategoriasForo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());



        }
    }
}
