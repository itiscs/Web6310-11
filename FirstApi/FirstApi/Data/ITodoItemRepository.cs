using FirstApi.Models;

namespace FirstApi.Data
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<ToDoItem>> GetTodos();
        Task<ToDoItem> GetTodoByID(long id);
        Task AddToDoItem(ToDoItem todo);
        Task DeleteToDoItem(long id);
        Task UpdateToDoItem(ToDoItem todo);
        Task Save();
    }
}
