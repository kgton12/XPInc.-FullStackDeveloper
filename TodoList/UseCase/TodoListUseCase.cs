using Microsoft.EntityFrameworkCore;
using TodoList.Context;
using TodoList.Enuns;
using TodoList.Models;

namespace TodoList.UseCase
{
    public class TodoListUseCase(TodoListContext context)
    {
        private readonly TodoListContext _context = context;

        public async Task<TodoListEntity> RegisterUseCase(TodoListEntity todoList)
        {
            var newTodoList = _context.TodoListEntitys.Add(new TodoListEntity
            {
                Title = todoList.Title,
                Description = todoList.Description,
                Date = todoList.Date,
                Status = Status.Pending
            });

            await _context.SaveChangesAsync();

            return newTodoList.Entity;
        }

        public async Task<TodoListEntity> GetTodoByIdUseCase(Guid id)
        {
            var todo = await _context.TodoListEntitys.FirstOrDefaultAsync(x => x.Id == id);

            return todo ?? throw new Exception("Tarefa Não encontrada.");
        }

        public async Task<List<TodoListEntity>> GetAllTodoUseCase()
        {
            var todo = await _context.TodoListEntitys.ToListAsync();

            return todo.Count > 0 ? todo : throw new Exception("Tarefa Não encontrada.");
        }

        public async Task<List<TodoListEntity>> GetTodoByTitleUseCase(string description)
        {
            var todo = await _context.TodoListEntitys.Where(x => x.Description == description).ToListAsync();

            return todo.Count > 0 ? todo : throw new Exception("Tarefa Não encontrada.");
        }

        public async Task<List<TodoListEntity>> GetTodoByDateUseCase(string date)
        {
            var parsedDate = DateTime.Parse(date);
            var todo = await _context.TodoListEntitys.Where(x => x.Date.Date == parsedDate.Date).ToListAsync();

            return todo.Count > 0 ? todo : throw new Exception("Tarefa Não encontrada.");
        }

        public async Task<List<TodoListEntity>> GetTodoByStatusUseCase(Status status)
        {
            var todo = await _context.TodoListEntitys.Where(x => x.Status == status).ToListAsync();

            return todo.Count > 0 ? todo : throw new Exception("Tarefa Não encontrada.");
        }

        public async Task<TodoListEntity> PutTodoByIdUseCase(Guid id, TodoListEntity todoList)
        {
            var existingTodo = await _context.TodoListEntitys.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Tarefa Não encontrada.");

            existingTodo.Title = todoList.Title;
            existingTodo.Description = todoList.Description;
            existingTodo.Date = todoList.Date;
            existingTodo.Status = todoList.Status;

            await _context.SaveChangesAsync();

            return existingTodo;
        }

        public async Task<Guid> DeleteTodoByIdUseCase(Guid id)
        {
            var existingTodo = await _context.TodoListEntitys.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Tarefa Não encontrada.");

            _context.TodoListEntitys.Remove(existingTodo);
            _context.SaveChanges();
            return existingTodo.Id;
        }
    }
}
