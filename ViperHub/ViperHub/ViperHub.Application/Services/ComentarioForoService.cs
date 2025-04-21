using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ViperHub.Application.Dto.Categorys;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Infrastructure.RepoInterfaces;

namespace ViperHub.Application.Services
{

    public class ComentarioForoService : IComentariosForoContract
    {

        protected readonly IComentariosForo _repository;
        protected readonly IMapper _mapper;

        public ComentarioForoService(IComentariosForo repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }

          public async Task<string> AddAsync(ComentariosForo entity)
    {
        try
        {
            // Validar que ComentarioPadreId sea null si es 0
            if (entity.ComentarioPadreId == 0)
            {
                entity.ComentarioPadreId = null;
            }

            // Llamar al repositorio para agregar el comentario
            await _repository.AddAsync(entity);

            return "Comentario creado con éxito.";
        }
        catch (Exception ex)
        {
            // Manejo de excepciones con un mensaje claro
            throw new Exception($"Error al crear el comentario: {ex.Message}");
        }
    }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return "";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<IReadOnlyList<ComentariosForo>> GetAllAsync()
        {
            try
            {
                var categories = await _repository.GetAllAsync();

            return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<ComentariosForo> GetByIdAsync(int id)
        {

            try
            {
                var category = await _repository.GetByIdAsync(id);
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<string> UpdateAsync(int id, ComentariosForo entity)
        {
            try
            {
                await _repository.UpdateAsync(id, entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return "";
        }

    }
}