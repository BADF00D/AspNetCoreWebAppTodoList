using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using AspNetCoreWebAppTodoList.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAppTodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(long id)
        {
            var item = _context.TodoItems.Find(id);
            return item ?? (ActionResult<TodoItem>) NotFound();
        }

        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new {id = item.Id}, item);
        }

    }
}