namespace TicTacToe.API.DAL.Repositories.Interface;

public interface IRepository<T> 
    : IDisposable 
    where T : class
{
    T Get(Guid id);
    void Create(T item); 
    void Update(T item);
    void Delete(Guid id);
    void Save();
}