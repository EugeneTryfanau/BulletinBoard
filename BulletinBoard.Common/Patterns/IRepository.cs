﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulletinBoard.Common.Patterns
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetItemByIdAsync(Guid id);

        Task<T> CreateAsync(T item);

        Task UpdateAsync(T item);

        Task<T> DeleteAsync(Guid id);
    }
}
