﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Dto.Comments;
using ViperHub.Application.Interfaces;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Domain.Models;

namespace ViperHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        
        protected readonly IComentariosForoContract _service;
        protected readonly IMapper _mapper;

        public CommentsController(IComentariosForoContract service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }


        [HttpGet(Name = "Comentarios")]
        public async Task<IActionResult> GetCategoriaForoAll()
        {
            var result = await _service.GetAllAsync();

            var returnAllCategorys = _mapper.Map<List<ComentarioForoResponse>>(result);

            return Ok(returnAllCategorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {


            var comments = await _service.GetByIdAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ComentarioForoResponse>(comments));
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(ComentarioForoDto NewComment)
        {


            var Comment = _mapper.Map<ComentariosForo>(NewComment);

            // Guardando la entidad en la base de datos
            await _service.AddAsync(Comment);

            // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
            var CommentDto = _mapper.Map<ComentarioForoDto>(Comment);

            return Ok(CommentDto); // Retornamos el DTO mapeado
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var Comment = await _service.GetByIdAsync(id);
            if (Comment == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            await _service.DeleteAsync(id);

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, ComentarioForoDto category)
        {
            var UpdateComment = _mapper.Map<ComentariosForo>(category);

            await _service.UpdateAsync(id, UpdateComment);
            if (_service == null)
            {
                return NotFound(UpdateComment);
            }


            return Ok(UpdateComment);
        }
        
    }

}

