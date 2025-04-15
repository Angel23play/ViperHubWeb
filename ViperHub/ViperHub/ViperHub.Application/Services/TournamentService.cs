using AutoMapper;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.RepoInterfaces;

namespace ViperHub.Application.Services
{

    public class TournamentService : ITorneosContract
    {

        protected readonly ITorneos _repository;
        protected readonly IMapper _mapper;

        public TournamentService(ITorneos repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(Torneo entity)
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

        public async Task<IReadOnlyList<Torneo>> GetAllAsync()
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

        public async Task<Torneo> GetByIdAsync(int id)
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

        public async Task<string> UpdateAsync(int id, Torneo entity)
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