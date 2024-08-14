using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Context
{
    public class TodoListContext(DbContextOptions<TodoListContext> options) : DbContext(options)
    {
        public DbSet<TodoListEntity> TodoListEntitys { get; set; }
    }
}
