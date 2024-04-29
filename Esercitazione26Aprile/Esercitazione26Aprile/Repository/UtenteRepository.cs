using Esercitazione26Aprile.Models;

namespace Esercitazione26Aprile.Repository
{
    public class UtenteRepository : IRepository<Utente>
    {
        private readonly Esercitazione26AprileContext ctx;

        public UtenteRepository(Esercitazione26AprileContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Delete(Utente t)
        {
            try
            {
                ctx.Utentes.Remove(t);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Utente> GetAll()
        {
            return ctx.Utentes.ToList();
        }

        public Utente GetByCodice(string codice)
        {
            return ctx.Utentes.First(u => u.CodiceUtente == codice);
        }

        public bool Insert(Utente t)
        {
            try
            {
                ctx.Utentes.Add(t);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Update(Utente t)
        {
            try
            {
                Utente temp = this.GetByCodice(t.CodiceUtente);

                if (temp is not null)
                {
                    t.UtenteId = temp.UtenteId;
                    t.CodiceUtente = temp.CodiceUtente;
                    t.Nominativo = t.Nominativo is not null ? t.Nominativo : temp.Nominativo;
                    t.Email = t.Email is not null ? t.Email : temp.Email;
                    t.Passsword = t.Passsword is not null ? t.Passsword : temp.Passsword;

                    ctx.Entry(temp).CurrentValues.SetValues(t);
                    ctx.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
