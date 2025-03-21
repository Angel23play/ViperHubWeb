using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class UsuarioClaneRepository : IUsuariosClan
    {
        protected readonly ViperHubContext _db;
        protected readonly IMapper _mapper;
        public UsuarioClaneRepository(ViperHubContext viperHubContext, IMapper mapper)
        {
            _db = viperHubContext;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(UsuarioClane entity)
        {


            _db.UsuarioClanes.Add(entity);
            await _db.SaveChangesAsync();
            return "The category has been created";

        }

        public async Task<string> DeleteAsync(int id)
        {
            var ClanMember = await GetByIdAsync(id);

            if (ClanMember == null) return "Category not found!";

            _db.UsuarioClanes.Remove(ClanMember);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }


        public async Task<IReadOnlyList<UsuarioClane>> GetAllAsync()
        {
            return await _db.UsuarioClanes.ToListAsync();

        }


        public async Task<UsuarioClane> GetByIdAsync(int id)
        {
            var ClanMember = await _db.UsuarioClanes.FindAsync(id);

            if (ClanMember == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return ClanMember;



        }

        public async Task<string> UpdateAsync(int id, UsuarioClane NewEntity)
        {
            var ClanMember = await GetByIdAsync(id);
            if (ClanMember == null)
            {
                return "The category has not updated";

            }


            _mapper.Map(NewEntity, ClanMember);

            await _db.SaveChangesAsync();

            return "The category has been updated";
        }
    }
}
