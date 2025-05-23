namespace JobExchangeLibrary.Services
{
    public interface IDataService<T>
    {
        void Add(T item);
        void Delete(int id);
        void Update(T item);
        T GetById(int id);
        List<T> GetAll();
        List<T> Search(string keyword);
    }
}