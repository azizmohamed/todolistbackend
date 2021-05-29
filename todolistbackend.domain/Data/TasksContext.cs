using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todolistbackend.domain.Model;

namespace todolistbackend.domain.Data
{
    public class TasksContext: DbContext
    {
        public TasksContext(DbContextOptions<TasksContext> options) : base(options)
        {
        }
        //entities
        public DbSet<TodoItem> Tasks { get; set; }
    }
}
