using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todolistbackend.domain.Model;

namespace todolistbackend.domain.Interfaces
{
    public interface ITasksRepository
    {
        Task<IAsyncEnumerable<TodoItem>> GetAsync();
        Task<TodoItem> GetAsync(Guid id);
        Task CreateAsync(TodoItem task);
        Task UpdateAsync(Guid id, TodoItem task);
        Task DeleteAsync(Guid id);
    }
}
