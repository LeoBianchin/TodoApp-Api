using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItem { get; set; }
    }
}