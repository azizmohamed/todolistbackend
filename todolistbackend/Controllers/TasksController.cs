using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITasksRepository tasksRepository, TasksContext tasksContext, ILogger<TasksController> logger)
        {
            _tasksRepository = tasksRepository;
            _tasksContext = tasksContext;
            _logger = logger;
        }

        /// <summary>
        /// Get List Of Tasks Items
        /// </summary>
        /// <remarks>
        /// List of created tasks with status reflected in completed field    
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<TodoItem>>> Get()
        {
            _logger.LogDebug("Request to get all tasks");
            return  Ok(await _tasksRepository.GetAsync());
        }

        /// <summary>
        /// Get one task item
        /// </summary>
        /// <remarks>
        /// Return one task item    
        /// </remarks>
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<TodoItem>> Get(Guid id)
        {
            _logger.LogDebug("Request to get one task");
            return Ok(await _tasksRepository.GetAsync(id));
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>
        ///  
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TodoItem task)
        {
            _logger.LogDebug("Request to create one task");
            await _tasksRepository.CreateAsync(task);
            await _tasksContext.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Modify an existing task
        /// </summary>
        /// <remarks>
        ///  
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] TodoItem task)
        {
            _logger.LogDebug("Request to modify one task");
            await _tasksRepository.UpdateAsync(id, task);
            await _tasksContext.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>
        ///  
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            _logger.LogDebug("Request to delete one task");
            await _tasksRepository.DeleteAsync(id);
            await _tasksContext.SaveChangesAsync();
            return Ok();
        }
    }
}
