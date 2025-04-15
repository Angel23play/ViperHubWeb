using AutoMapper;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.RepoInterfaces;

namespace ViperHub.Application.Services
{

    public class MultimediumService : IMultimediumContract
    {

        protected readonly IMultimedium _repository;
        protected readonly IMapper _mapper;

        public MultimediumService(IMultimedium repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(Multimedium entity)
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

        public async Task<IReadOnlyList<Multimedium>> GetAllAsync()
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

        public async Task<Multimedium> GetByIdAsync(int id)
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

        public async Task<string> UpdateAsync(int id, Multimedium entity)
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