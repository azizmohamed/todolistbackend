using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todolistbackend.domain.Interfaces;
using todolistbackend.domain.Model;

namespace todolistbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        ITasksRepository _tasksRepository;
        public TasksController(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _tasksRepository.Get();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public TodoItem Get(Guid id)
        {
            return _tasksRepository.Get(id);
        }

        // POST: api/Tasks
        [HttpPost]
        public void Post([FromBody] TodoItem task)
        {
            _tasksRepository.Create(task);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] TodoItem task)
        {
            _tasksRepository.Update(id, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _tasksRepository.Delete(id);
        }
    }
}
