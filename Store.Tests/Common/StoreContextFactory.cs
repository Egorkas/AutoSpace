using Microsoft.EntityFrameworkCore;
using Store.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Common
{
    public class StoreContextFactory
    {
        //Create Db Context
        public static StoreDbContext Create()
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new StoreDbContext(options);
            context.Database.EnsureCreated();

            return context;
        }

        public static void Destroy(StoreDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
