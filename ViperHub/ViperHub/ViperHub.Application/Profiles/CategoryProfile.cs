using AutoMapper;
using ViperHub.Application.Foro.Dto.Categorys;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Profiles
{
   public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {

            CreateMap<CategoriasForo, CategoriaForoResponse>();
            CreateMap<CategoriaForoDto, CategoriasForo>();

           
               
        }
    }
}
