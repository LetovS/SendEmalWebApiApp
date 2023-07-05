using SendEmalWebApi.Model;

namespace SendEmalWebApi.Repositories
{
    /// <summary>
    /// Работа с данными.
    /// </summary>
    /// <remarks>
    /// Этот интерфейс определяет сигнатуру методов необходимых для работы с базой данных.
    /// </remarks>
    /// <typeparam name="T">Объект базы данных.</typeparam>    
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// Получение всех записей из базы данных.
        /// </summary>
        /// <returns>
        /// Возвращает колекцию типа,
        /// <typeparamref name="T"/>
        /// с базы данных.
        /// </returns>
        public Task<List<T>> GetAll();
        /// <summary>
        /// Добавление новой записи в базу данных.
        /// </summary>
        /// <param name="model">Объект.</param>
        public Task Add(T model);
    }
}
