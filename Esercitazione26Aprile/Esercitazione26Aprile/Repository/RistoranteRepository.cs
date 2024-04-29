using Esercitazione26Aprile.Models;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione26Aprile.Repository
{
    public class RistoranteRepository : IRepository<Ristorante>
    {
        private readonly Esercitazione26AprileContext ctx;
        public RistoranteRepository(Esercitazione26AprileContext ctx) 
        {
            this.ctx = ctx;
        }

        public bool Delete(Ristorante t)
        {
            return false;
        }

        public List<Ristorante> GetAll()
        {
            return ctx.Ristorantes.ToList();
        }

        public Ristorante GetByCodice(string codice)
        {
            return ctx.Ristorantes.First(r => r.CodiceRistorante == codice);
        }

        public bool Insert(Ristorante t)
        {
            return false;
        }

        public bool Update(Ristorante t)
        {
            return false;
        }

    }
}
