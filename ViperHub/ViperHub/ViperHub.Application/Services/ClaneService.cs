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

    public class ClaneService : IClanesContract
    {

        protected readonly IClanes _repository;
        protected readonly IMapper _mapper;

        public ClaneService(IClanes repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(Clane entity)
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

        public async Task<IReadOnlyList<Clane>> GetAllAsync()
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

        public async Task<Clane> GetByIdAsync(int id)
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

        public async Task<string> UpdateAsync(int id, Clane entity)
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