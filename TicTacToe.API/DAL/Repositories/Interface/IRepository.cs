namespace TicTacToe.API.DAL.Repositories.Interface;

public interface IRepository<T> 
    : IDisposable 
    where T : class
{
    /// <summary>
    /// получение одного объекта по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    T Get(Guid id); // 
    void Create(T item); // создание объекта
    void Update(T item); // обновление объекта
    void Delete(Guid id); // удаление объекта по id
    void Save();  // сохранение изменений
}