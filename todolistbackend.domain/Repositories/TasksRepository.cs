using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todolistbackend.domain.Data;
using todolistbackend.domain.Interfaces;
using todolistbackend.domain.Model;
using System.Linq;

namespace todolistbackend.domain.Repositories
{
    public class TasksRepository: ITasksRepository
    {
        TasksContext _tasksContext;
        public TasksRepository(TasksContext tasksContext)
        {
            _tasksContext = tasksContext;
        }

        public async Task CreateAsync(TodoItem task)
        {
            task.Id = new Guid();
            task.Completed = false;
            await _tasksContext.Tasks.AddAsync(task);
        }

        public async Task DeleteAsync(Guid id)
        {
            var removedItem = await GetAsync(id);
            _tasksContext.Tasks.Remove(removedItem);
        }

        public async Task<IAsyncEnumerable<TodoItem>> GetAsync()
        {
            return  _tasksContext.Tasks.AsAsyncEnumerable();
        }

        public async Task<TodoItem> GetAsync(Guid id)
        {
            return await _tasksContext.Tasks.FindAsync(id);
        }

        public async Task UpdateAsync(Guid id, TodoItem task)
        {
            var updatedTask = await _tasksContext.Tasks.FindAsync(id);
            updatedTask.Completed = task.Completed;
        }
    }
}
