using System;
using System.Collections.Generic;
using todolistbackend.domain.Model;

namespace todolistbackend.domain.Interfaces
{
    public interface ITasksRepository
    {
        IEnumerable<TodoItem> Get();
        TodoItem Get(Guid id);
        void Create(TodoItem task);
        void Update(Guid id, TodoItem task);
        void Delete(Guid id);
    }
}
