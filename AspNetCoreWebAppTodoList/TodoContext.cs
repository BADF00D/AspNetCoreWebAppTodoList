using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreWebAppTodoList.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;

namespace AspNetCoreWebAppTodoList
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class TodoContext : DbContext, ITodoContext

    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        
        EntityEntry<TodoItem> ITodoContext.Add(TodoItem item)
        {
            return TodoItems.Add(item);
        }

        Task<EntityEntry<TodoItem>> ITodoContext.AddAsync(TodoItem item)
        {
            return TodoItems.AddAsync(item);
        }

        bool ITodoContext.Any()
        {
            return TodoItems.Any();
        }

        Task<TodoItem> ITodoContext.FindAsync(long id)
        {
            return TodoItems.FindAsync(id);
        }

        EntityEntry<TodoItem> ITodoContext.Remove(TodoItem item)
        {
            return TodoItems.Remove(item);
        }

        int ITodoContext.SaveChanges()
        {
            return SaveChanges();
        }

        Task<int> ITodoContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return SaveChangesAsync(cancellationToken);
        }

        Task<List<TodoItem>> ITodoContext.ToListAsync()
        {
            return TodoItems.ToListAsync();
        }

        EntityEntry<TodoItem> ITodoContext.Update(TodoItem item)
        {
            return TodoItems.Update(item);
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}