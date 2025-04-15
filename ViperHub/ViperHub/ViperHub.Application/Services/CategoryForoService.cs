using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ViperHub.Application.Dto.Categorys;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.RepoInterfaces;
using ViperHub.Application.Interfaces.Service;



namespace ViperHub.Application.Services
{

    public class CategoryForoService : ICategoryForoContract
    {
        
        protected readonly ICategoriaForo _repository;
        protected readonly IMapper _mapper;

        public CategoryForoService(ICategoriaForo repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<string> AddAsync(CategoriasForo entity)
        {
            try
            {
                await _repository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return "";
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

        public async Task<IReadOnlyList<CategoriasForo>> GetAllAsync()
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

        public async Task<CategoriasForo> GetByIdAsync(int id)
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

        public async Task<string> UpdateAsync(int id, CategoriasForo entity)
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