using System;
using System.Collections.Generic;
using todolistbackend.domain.Data;
using todolistbackend.domain.Interfaces;
using todolistbackend.domain.Model;

namespace todolistbackend.domain.Repositories
{
    public class TasksRepository: ITasksRepository
    {
        TasksContext _tasksContext;
        public TasksRepository(TasksContext tasksContext)
        {
            _tasksContext = tasksContext;
        }

        public void Create(TodoItem task)
        {
            _tasksContext.Tasks.Add(task);
        }

        public void Delete(Guid id)
        {
            _tasksContext.Tasks.Remove(Get(id));
        }

        public IEnumerable<TodoItem> Get()
        {
            return _tasksContext.Tasks;
        }

        public TodoItem Get(Guid id)
        {
            return _tasksContext.Tasks.Find(id);
        }

        public void Update(Guid id, TodoItem task)
        {
            _tasksContext.Tasks.Find(id).Completed = task.Completed;
        }
    }
}
