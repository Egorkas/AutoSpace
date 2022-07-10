using AutoMapper;
using Shouldly;
using Store.Application.Products;
using Store.Persistence;
using Store.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetProductQueryHandlerTests
    {
        private readonly StoreDbContext Context;
        private readonly IMapper Mapper;
        public GetProductQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetProductQueryHandler_Success()
        {
            var handler = new GetProductQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetProductQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
