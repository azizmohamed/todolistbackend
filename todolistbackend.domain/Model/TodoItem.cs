using System;
namespace todolistbackend.domain.Model
{
    public class TodoItem
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public bool Completed { get; set; }
    }
}
