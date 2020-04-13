using Microsoft.EntityFrameworkCore;

namespace MiniProfillerPoc.Models
{
    public class TodoDbContext: DbContext
    {
        public DbSet<Todo> TodoCollection { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}