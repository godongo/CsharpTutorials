using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Linq;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    //[Route("api/Todo")]
    //[Route("api/[controller]")]
    [Route("api/todo")]
    public class TodoController : Controller
    {
        // This context use in-memory db, defined in configureServices in Startup.cs
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            // Add TodoItem if table is empty.
            if(_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Doctors appointment", IsComplete = false  });
                _context.TodoItems.Add(new TodoItem { Name = "Attend meeting", IsComplete = true });
                _context.TodoItems.Add(new TodoItem { Name = "Afternoon nap", IsComplete = false });
                _context.TodoItems.Add(new TodoItem { Name = "Shopping", IsComplete = true });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            // HttpStatusCode: 200
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                // HttpStatusCode: 404
                return NotFound();
            }

            // HttpStatusCode: 200
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            // HttpStatusCode: 201
            // Adds a Location header to the response, URI of the newly created to-do item.
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                // HttpStatusCode: 204(No Content)
                return BadRequest();
            }

            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}