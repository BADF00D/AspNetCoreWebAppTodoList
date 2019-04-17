using AspNetCoreWebAppTodoList.Model;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppTodoList
{
    public interface ITodoContext
    {
        DbSet<TodoItem> TodoItems { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}