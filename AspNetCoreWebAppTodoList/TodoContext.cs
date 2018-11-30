using AspNetCoreWebAppTodoList.Model;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppTodoList
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class TodoContext : DbContext

    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}