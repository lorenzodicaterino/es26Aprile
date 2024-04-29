namespace Esercitazione26Aprile.Repository
{
    public interface IRepository<T>
    {
        bool Insert(T t);
        bool Delete(T t);
        bool Update(T t);
        List<T> GetAll();
        T GetByCodice(string codice);
    }
}
