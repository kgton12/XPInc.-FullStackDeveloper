using TodoList.Enuns;

namespace TodoList.Models
{
    public class TodoListEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Pending;
    }
}
