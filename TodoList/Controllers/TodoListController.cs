using Microsoft.AspNetCore.Mvc;
using TodoList.Context;
using TodoList.Enuns;
using TodoList.Models;
using TodoList.UseCase;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController(TodoListContext context) : ControllerBase
    {
        private readonly TodoListUseCase useCase = new(context);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            try
            {
                var response = await useCase.GetTodoByIdUseCase(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoById(Guid id, [FromBody] TodoListEntity todoList)
        {
            try
            {
                var response = await useCase.PutTodoByIdUseCase(id, todoList);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoById(Guid id)
        {
            try
            {
                var response = await useCase.DeleteTodoByIdUseCase(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTodos()
        {
            try
            {
                var response = await useCase.GetAllTodoUseCase();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetByTitle/{title}")]
        public async Task<IActionResult> GetTodoByTitle(string title)
        {
            try
            {
                var response = await useCase.GetTodoByTitleUseCase(title);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetByDate/{data}")]
        public async Task<IActionResult> GetTodoByDate(string data)
        {
            try
            {
                var response = await useCase.GetTodoByDateUseCase(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetByStatus/{status}")]
        public async Task<IActionResult> GetTodoByStatus(Status status)
        {
            try
            {
                var response = await useCase.GetTodoByStatusUseCase(status);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTodo(TodoListEntity todoList)
        {
            try
            {
                var response = await useCase.RegisterUseCase(todoList);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
