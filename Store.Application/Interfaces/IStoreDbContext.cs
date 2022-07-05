using Microsoft.EntityFrameworkCore;
using Store.Domain;

namespace Store.Application.Interfaces
{
    public interface IStoreDbContext
    {
        DbSet<Shop> Shops { get; set; }
        DbSet<Shop> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
