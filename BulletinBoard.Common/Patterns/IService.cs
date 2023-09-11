using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulletinBoard.Common.Patterns
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetItemByIdAsync(int id);

        Task<T> CreateAsync(T item);

        Task UpdateAsync(T item);

        Task<T> DeleteAsync(int id);
    }
}
