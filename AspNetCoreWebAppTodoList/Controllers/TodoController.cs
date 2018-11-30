﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public ActionResult<TodoItem> GetById([FromQuery]long id)
        {
            var item = _context.TodoItems.Find(id);
            return item ?? (ActionResult<TodoItem>) NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody, Required]TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromQuery]long id, [FromBody, Required]TodoItem item)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null) return NotFound();

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
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