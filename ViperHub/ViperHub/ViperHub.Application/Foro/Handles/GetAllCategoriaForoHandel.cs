using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Application.Foro.Dto;
using ViperHub.Domain.Interfaces;

namespace ViperHub.Application.Foro.Handles
{
    public class GetAllCategoriaForoHandel
    {
        protected readonly ICategoriaForo _repository;

        public GetAllCategoriaForoHandel(ICategoriaForo categoriaForo)
        {
            _repository = categoriaForo;
        }

        public List<CategoriaForoDto> GetAll()
        {
            var result = _repository.GetAll();

            return result.Select(c => new CategoriaForoDto
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
        }
    }
}
