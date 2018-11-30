using AspNetCoreWebAppTodoList.Model;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppTodoList
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}