using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Foro.Dto.Multimedium;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;

namespace ViperHub.Api.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class MultimediumController : ControllerBase
    {
        


            protected readonly IMultimedium _repository;
            protected readonly IMapper _mapper;

            public MultimediumController(IMultimedium repository, IMapper mapper)
            {

                _repository = repository;
                _mapper = mapper;
            }


            [HttpGet(Name = "Multimedias")]
            public async Task<IActionResult> GetCategoriaForoAll()
            {
                var result = await _repository.GetAllAsync();

                var returnAllMedias = _mapper.Map<List<MultimediumResponse>>(result);

                return Ok(returnAllMedias);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetMedia(int id)
            {


                var Media = await _repository.GetByIdAsync(id);
                if (Media == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<MultimediumResponse>(Media));
            }

            [HttpPost]
            public async Task<IActionResult> AddMedia(MultimediumDto NewCategory)
            {


                var categoryEntity = _mapper.Map<Multimedium>(NewCategory);

                // Guardando la entidad en la base de datos
                await _repository.AddAsync(categoryEntity);

                // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
                var categoryDto = _mapper.Map<MultimediumResponse>(categoryEntity);

                return Ok(categoryDto); // Retornamos el DTO mapeado
            }

            [HttpDelete]
            public async Task<IActionResult> DeleteCategory(int id)
            {
                var Category = await _repository.GetByIdAsync(id);
                if (Category == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }

                await _repository.DeleteAsync(id);

                return NoContent();
            }
            [HttpPut]
            public async Task<IActionResult> UpdateMedia(int id, MultimediumDto category)
            {
                var UpdateMedia = _mapper.Map<Multimedium>(category);

                await _repository.UpdateAsync(id, UpdateMedia);
                if (_repository == null)
                {
                    return NotFound(UpdateMedia);
                }


                return Ok(UpdateMedia);
            }
        
    }
}
