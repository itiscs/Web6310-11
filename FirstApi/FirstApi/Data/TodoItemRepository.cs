using FirstApi.Models;
using static FirstApi.Data.TodoItemRepository;

namespace FirstApi.Data
{
    public class TodoItemRepository:ITodoItemRepository
    {
        private readonly MyBaseContext _db;
        public TodoItemRepository(MyBaseContext db)
        {
            _db = db;
        }

        public async Task AddToDoItem(ToDoItem todo)
        {
            await _db.AddAsync(todo);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteToDoItem(long id)
        {
            var todo = await GetTodoByID(id);
            _db.TodoItems.Remove(todo);
            await _db.SaveChangesAsync();
        }

        public async Task<ToDoItem> GetTodoByID(long id)
        {
            return await _db.TodoItems.FindAsync(id);
        }

        public async Task<IEnumerable<ToDoItem>> GetTodos()
        {
            return _db.TodoItems.ToList();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
                   
        public async Task UpdateToDoItem(ToDoItem todo)
        {
            _db.TodoItems.Update(todo);
        }
    }    
}
