using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreWebAppTodoList.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AspNetCoreWebAppTodoList.Context
{
    public interface IVoltageContext
    {
        bool Any();
        Task<EntityEntry<VoltageItem>> AddAsync(VoltageItem item);
        Task AddRangeAsync(VoltageItem[] items);
        Task<List<VoltageItem>> ToListAsync();
        Task<VoltageItem> FindAsync(long id);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    class VoltageContext : DbContext, IVoltageContext
    {
        public VoltageContext(DbContextOptions<VoltageContext> options): base(options)
        {
        }

        public DbSet<VoltageItem> VoltageItems { get; set; }

        public bool Any()
        {
            return VoltageItems.Any();
        }

        public Task<EntityEntry<VoltageItem>> AddAsync(VoltageItem item)
        {
            return VoltageItems.AddAsync(item);
        }

        public Task AddRangeAsync(VoltageItem[] items)
        {
            return VoltageItems.AddRangeAsync(items);
        }

        public Task<List<VoltageItem>> ToListAsync()
        {
            return VoltageItems.ToListAsync();
        }

        public Task<VoltageItem> FindAsync(long id)
        {
            return VoltageItems.FindAsync(id);
        }
    }
}