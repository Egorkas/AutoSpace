using AutoMapper;
using Store.Application.Common.Mappings;
using Store.Application.Interfaces;
using Store.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public StoreDbContext Context;
        public IMapper Mapper;
        public QueryTestFixture()
        {
            Context = StoreContextFactory.Create();
            var configurationBuilder = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IStoreDbContext).Assembly));
            });
            Mapper = configurationBuilder.CreateMapper(); 
        }

        public void Dispose()
        {
            StoreContextFactory.Destroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
    }
}
