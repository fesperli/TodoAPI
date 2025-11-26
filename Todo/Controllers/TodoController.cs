using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Data;
using Todo.API.Models;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private AppDbContext _context = new AppDbContext();

        [HttpGet]
        public List<TodoModel> GetTodos()
        {
            return _context.Todos.ToList();
        }
        [HttpGet("{id}")] //buscar 1 por id
        public TodoModel SelectidTodo(Guid id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo is null)
            { 
                return null;
            }
            return todo;
        }

        [HttpPost]
        public ActionResult AddTodo([FromBody] TodoModel todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return Created();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(Guid id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo is null)
            {
                return NotFound();
            }
                _context.Todos.Remove(todo);
                _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public TodoModel UpdateTodo(Guid id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo is null)
            {
                return null;
            }
            todo.IsCompleted = !todo.IsCompleted;

            _context.SaveChanges();
            return todo;
    }
}
