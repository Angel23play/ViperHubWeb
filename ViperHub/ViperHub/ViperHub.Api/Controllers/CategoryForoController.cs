using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ViperHub.Application.Foro.Dto;
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

        public CategoryForoController(ICategoriaForo repository)
        {
            _repository = repository;
        }


        [HttpGet(Name = "Categoria")]
        public async Task<IActionResult> GetCategoriaForoAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
      

            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoriasForo NewCategory) {

            await _repository.AddAsync(NewCategory);
            return Ok();
        }
        
    [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _repository.DeleteAsync(id);

            if (_repository == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRepository(int id)
        {
            await _repository.UpdateAsync(id);
            if (_repository == null)
            {
                return NotFound(id);
            }
            return Ok();
        }
    }

}

