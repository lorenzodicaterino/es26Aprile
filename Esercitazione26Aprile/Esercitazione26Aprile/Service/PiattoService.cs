using Esercitazione26Aprile.DTO;
using Esercitazione26Aprile.Models;
using Esercitazione26Aprile.Repository;

namespace Esercitazione26Aprile.Service
{
    public class PiattoService : IService<PiattoDTO>
    {
        private readonly PiattoRepository repo;

        public PiattoService(PiattoRepository repo)
        {
            this.repo = repo;
        }

        public bool Elimina(string codice)
        {
            return false;
        }

        public bool Inserisci(PiattoDTO t)
        {
            return false;
        }

        public bool Modifica(PiattoDTO t)
        {
            return false;
        }

        public PiattoDTO RecuperaPerCodice(string codice)
        {
            Piatto p = repo.GetByCodice(codice);

            PiattoDTO dto = new PiattoDTO()
            {
                Cod = p.CodicePiatto,
                Nom = p.NomePiatto,
                Des = p.DescrizionePiatto,
                Pre = p.PrezzoPiatto
            };

            return dto;
        }

        public List<PiattoDTO> RecuperaTutti()
        {
            return repo.GetAll().Select(p => new PiattoDTO()
            {
                Cod = p.CodicePiatto,
                Nom = p.NomePiatto,
                Des = p.DescrizionePiatto,
                Pre = p.PrezzoPiatto
            }).ToList();
        }

        public List<PiattoDTO> RecuperaPiattiPerRistorante(string codice)
        {
            return repo.GetPiattiByRistorante(codice).Select(p => new PiattoDTO()
            {
                Cod = p.CodicePiatto,
                Nom = p.NomePiatto,
                Des = p.DescrizionePiatto,
                Pre = p.PrezzoPiatto
            }).ToList();
        }
    }
}
