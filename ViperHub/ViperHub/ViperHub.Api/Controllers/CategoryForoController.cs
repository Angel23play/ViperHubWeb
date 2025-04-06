using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ViperHub.Application.Dto.Categorys;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Repository;

namespace ViperHub.Api.Controllerss
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryForoController : ControllerBase
    {

        protected readonly ICategoriaForo _repository;
        protected readonly IMapper _mapper;

        public CategoryForoController(ICategoriaForo repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "Categoria")]
        public async Task<IActionResult> GetCategoriaForoAll()
        {
            var result = await _repository.GetAllAsync();

            var returnAllCategorys = _mapper.Map<List<CategoriaForoResponse>>(result);

            return Ok(returnAllCategorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {


            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoriaForoResponse>(category));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoriaForoDto NewCategory) {

            try
            {


                var categoryEntity = _mapper.Map<CategoriasForo>(NewCategory);

                // Guardando la entidad en la base de datos
                await _repository.AddAsync(categoryEntity);

                // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
                var categoryDto = _mapper.Map<CategoriaForoDto>(categoryEntity);

                return Ok(categoryDto); // Retornamos el DTO mapeado
            }
            catch (Exception ex) 
            {
                return NotFound($"Error: {ex.Message}".ToString());
            }

        }
        
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }
     [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoriaForoDto category)
        {
            var UpdateCategory = _mapper.Map<CategoriasForo>(category);

            await _repository.UpdateAsync(id,UpdateCategory);
            if (_repository == null)
            {
                return NotFound(UpdateCategory);
            }

            
            return Ok(UpdateCategory);
        }
    }

}

