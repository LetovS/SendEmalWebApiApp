namespace SendEmalWebApi.Model
{
    /// <summary>
    /// Базовая сущность базы данных.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Индентификатор.
        /// </summary>
        public int Id { get; set; }
    }
}
