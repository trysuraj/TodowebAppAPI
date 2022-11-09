using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAppAPI.Data;
using TodoWebAppAPI.models;

namespace TodoWebAppAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TodoController : Controller
    {
        private readonly TodosAPIDbContext dbContext;
        public TodoController(TodosAPIDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {

            return Ok(await dbContext.Todos.ToListAsync());

        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTodo([FromRoute] Guid id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodos(AddTodoRequest addTodoRequest)
        {
            var Todo = new Todo()
            {
                Id = Guid.NewGuid(),
                Task = addTodoRequest.Task,
                Date = addTodoRequest.Date
            };
            await dbContext.Todos.AddAsync(Todo);
            await dbContext.SaveChangesAsync();
            return Ok(Todo);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, UpdateTodoRequest updateTodoRequest)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.Task = updateTodoRequest.Task;
                todo.Date = updateTodoRequest.Date;

                await dbContext.SaveChangesAsync();
                return Ok(todo);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] Guid id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo != null)
            {
                dbContext.Todos.Remove(todo);
                await dbContext.SaveChangesAsync();
                return Ok(todo);
            }
            return NotFound();
        }
    }
}
