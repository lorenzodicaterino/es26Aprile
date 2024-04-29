using Esercitazione26Aprile.Models;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione26Aprile.Repository
{
    public class PiattoRepository : IRepository<Piatto>
    {
        private readonly Esercitazione26AprileContext ctx;

        public PiattoRepository (Esercitazione26AprileContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Delete(Piatto t)
        {
            return false;
        }

        public List<Piatto> GetAll()
        {
            return ctx.Piattos.ToList();
        }

        public Piatto GetByCodice(string codice)
        {

            return ctx.Piattos.First(p => p.CodicePiatto == codice);
        }

        public bool Insert(Piatto t)
        {
            return false;
        }

        public bool Update(Piatto t)
        {
            return false;
        }
        public List<Piatto> GetPiattiByRistorante(string codice)
        {
            return ctx.Piattos.Include(p => p.RistoranteRifNavigation).Where(p => p.RistoranteRifNavigation.CodiceRistorante == codice).ToList();
        }
    }
}
