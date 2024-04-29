namespace Esercitazione26Aprile.Service
{
    public interface IService<T>
    {
        bool Inserisci(T t);
        bool Elimina(string codice);
        bool Modifica(T t);
        List<T> RecuperaTutti();
        T RecuperaPerCodice (string codice);
    }
}
