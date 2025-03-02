using ViperHub.Domain.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class EquiposTorneoRepository : IEquiposTorneos
    {
        protected readonly ViperHubContext _db;
        public EquiposTorneoRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }
        public void Add(EquiposTorneo equiposTorneo)
        {
            _db.EquiposTorneos.Add(equiposTorneo);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
          
        }

        public IEnumerable<EquiposTorneo> GetAll()
        {
            return _db.EquiposTorneos.ToList();
        }

        public EquiposTorneo GetById(int id)
        {
            return _db.EquiposTorneos.Where(x=>x.Id==id).FirstOrDefault();
        }

        public EquiposTorneo Update(EquiposTorneo equiposTorneo)
        {
            throw new NotImplementedException();
        }
    }
}
