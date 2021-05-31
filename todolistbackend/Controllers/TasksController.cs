using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todolistbackend.domain.Data;
using todolistbackend.domain.Interfaces;
using todolistbackend.domain.Model;

namespace todolistbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        ITasksRepository _tasksRepository;
        TasksContext _tasksContext;
        public TasksController(ITasksRepository tasksRepository, TasksContext tasksContext)
        {
            _tasksRepository = tasksRepository;
            _tasksContext = tasksContext;
        }
        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<TodoItem>>> Get()
        {
            return  Ok(await _tasksRepository.GetAsync());
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<TodoItem>> Get(Guid id)
        {
            return Ok(await _tasksRepository.GetAsync(id));
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TodoItem task)
        {
            await _tasksRepository.CreateAsync(task);
            await _tasksContext.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] TodoItem task)
        {
            await _tasksRepository.UpdateAsync(id, task);
            await _tasksContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _tasksRepository.DeleteAsync(id);
            await _tasksContext.SaveChangesAsync();
            return Ok();
        }
    }
}
