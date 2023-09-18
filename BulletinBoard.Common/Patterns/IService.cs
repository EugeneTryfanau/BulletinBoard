namespace BulletinBoard.Common.Patterns
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetItemByIdAsync(Guid id);

        Task<T> CreateAsync(T item);

        Task UpdateAsync(T item);

        Task<int> DeleteAsync(Guid id);
    }
}
