using Esercitazione26Aprile.DTO;
using Esercitazione26Aprile.Models;
using Esercitazione26Aprile.Repository;

namespace Esercitazione26Aprile.Service
{
    public class UtenteService : IService<UtenteDTO>
    {
        private readonly UtenteRepository repo;

        public UtenteService (UtenteRepository repo)
        {
            this.repo = repo;
        }

        public bool Elimina(string codice)
        {
            Utente u = repo.GetByCodice(codice);

            if (u is not null)
                return repo.Delete(u);

            return false;
        }

        public bool Inserisci(UtenteDTO t)
        {

            foreach(Utente xu in repo.GetAll())
            {
                if (xu.Email == t.Ema)
                    return false;
            }

            Utente u = new Utente()
            {
                CodiceUtente = Guid.NewGuid().ToString().ToUpper(),
                Nominativo = t.Nom,
                Email = t.Ema,
                Passsword = t.Pas
            };

            return repo.Insert(u);
        }

        public bool Modifica(UtenteDTO t)
        {
            Utente u = repo.GetByCodice(t.Cod);

            if (u is not null)
            {
                u.Passsword = t.Pas;
                u.Nominativo = t.Nom;
            }

            return repo.Update(u);
        }

        public UtenteDTO RecuperaPerCodice(string codice)
        {
            Utente u = repo.GetByCodice(codice);

            UtenteDTO dto = new UtenteDTO()
            {
                Cod = u.CodiceUtente,
                Ema = u.Email,
                Nom = u.Nominativo,
                Pas = u.Passsword
            };

            return dto;
        }

        public List<UtenteDTO> RecuperaTutti()
        {
            return repo.GetAll().Select(u => new UtenteDTO()
            {
                Cod= u.CodiceUtente,
                Ema= u.Email,
                Nom = u.Nominativo,
                Pas = u.Passsword
            }).ToList();
        }
    }
}
