using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AspNetCoreWebAppTodoList.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAppTodoList.api.V1
{
    /// <summary>
    /// Controller for manipulation ToDo-Items.
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/todo")]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
            if (_context.TodoItems.Any()) return;

            AddDummyData();
        }

        private void AddDummyData()
        {
            _context.TodoItems.Add(new TodoItem {Name = "Items1"});
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all ToDo-Items.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<TodoItem>), 200)]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        /// <summary>
        /// Gets single ToDo-Item by its Id.
        /// </summary>
        /// <param name="id">It from ToDo-Items to get.</param>
        /// <response code="200">Returns ToDo-Item.</response>
        /// <response code="404">Returns ToDo-Item with given Id not found.</response>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTodo")]
        [ProducesResponseType(typeof(TodoItem), 200)]
        [ProducesResponseType(404)]
        public ActionResult<TodoItem> GetById([FromRoute]long id)
        {
            var item = _context.TodoItems.Find(id);
            return item ?? (ActionResult<TodoItem>) NotFound();
        }

        /// <summary>
        /// Creates a ToDo-Item.
        /// </summary>
        /// <param name="item">ToDo-Items to create.</param>
        /// <response code="201">ToDo-Item created successfully.</response>
        /// <response code="400">Invalid or missing properties.</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Create([FromBody, Required]TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new {id = item.Id}, item);
        }

        /// <summary>
        /// Updates a ToDo-Item.
        /// </summary>
        /// <param name="id">Id of ToDo-Item to update.</param>
        /// <param name="item">Data of ToDo-Item.</param>
        /// <response code="204">ToDo-Items updated successfully.</response>
        /// <response code="400">Invalid or missing properties.</response>
        /// <response code="404">ToDo-Items with given Id not found.</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Update([FromRoute]long id, [FromBody, Required]TodoItem item)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null) return NotFound();

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Delete a ToDo-Item.
        /// </summary>
        /// <param name="id">Id of ToDo-Item to delete.</param>
        /// <response code="204">ToDo-Items deleted successfully.</response>
        /// <response code="404">ToDo-Items with given Id not found.</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete([FromQuery]long id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null) return NotFound();

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}