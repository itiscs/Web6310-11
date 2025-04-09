using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data
{
    public class MyBaseContext : DbContext
    {
        public MyBaseContext(DbContextOptions<MyBaseContext> options)
        : base(options)
        {
        }

        public DbSet<ToDoItem> TodoItems { get; set; } = null!;
    }
}
