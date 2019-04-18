using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreWebAppTodoList.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AspNetCoreWebAppTodoList
{
    public interface ITodoContext
    {
        bool Any();
        EntityEntry<TodoItem> Add(TodoItem item);
        Task<EntityEntry<TodoItem>> AddAsync(TodoItem item);
        Task<List<TodoItem>> ToListAsync();
        Task<TodoItem> FindAsync(long id);
        EntityEntry<TodoItem> Update(TodoItem item);
        EntityEntry<TodoItem> Remove(TodoItem item);
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}