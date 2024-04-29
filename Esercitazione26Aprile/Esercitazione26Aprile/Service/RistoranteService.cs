using Esercitazione26Aprile.DTO;
using Esercitazione26Aprile.Models;
using Esercitazione26Aprile.Repository;

namespace Esercitazione26Aprile.Service
{
    public class RistoranteService : IService<RistoranteDTO>
    {
        private readonly RistoranteRepository repo;
        private readonly PiattoService piatto;
        public RistoranteService(RistoranteRepository repo, PiattoService piatto)
        {
            this.repo = repo;
            this.piatto = piatto;
        }

        public bool Elimina(string codice)
        {
            return false;
        }

        public bool Inserisci(RistoranteDTO t)
        {
            return false;
        }

        public bool Modifica(RistoranteDTO t)
        {
            return false;
        }

        public RistoranteDTO RecuperaPerCodice(string codice)
        {
            Ristorante r = repo.GetByCodice(codice);

            RistoranteDTO dto = new RistoranteDTO()
            {
                Cod = r.CodiceRistorante,
                Nom = r.NomeRistorante,
                Ape = r.OrarioApertura,
                Chi = r.OrarioChiusura,
                Des = r.Descrizione,
                Tip = r.Tipologia
            };

            return dto;

        }

        public List<RistoranteDTO> RecuperaTutti()
        {
            return repo.GetAll().Select(r => new RistoranteDTO()
            {
                Cod = r.CodiceRistorante,
                Ape = r.OrarioApertura,
                Chi = r.OrarioChiusura,
                Des = r.Descrizione,
                Nom = r.NomeRistorante,
                Tip = r.Tipologia
            }).ToList();
        }

        public List<PiattoDTO> RecuperaPiattiPerRistorante(string codice)
        {
            return piatto.RecuperaPiattiPerRistorante(codice);
        }
    }
}
