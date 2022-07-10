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
    public class GetProductByShopIdQueryHandlerTests
    {
        private readonly StoreDbContext Context;
        private readonly IMapper Mapper;
        public GetProductByShopIdQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetProductByShopIdQueryHandler_Success()
        {
            var handler = new GetProductByShopIdQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetProductByShopIdQuery{
                    ShopId = Guid.Parse("18DD943B-73BE-47C9-8A89-E440ACCB4A1D")
                },
                CancellationToken.None);

            result.Count.ShouldBe(2);
            result.ShouldBeOfType<List<ProductDto>>();
        }

        [Fact]
        public async Task GetProductByShopIdQueryHandler_SuccessOnWrongShopId()
        {
            var handler = new GetProductByShopIdQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetProductByShopIdQuery
                {
                    ShopId = Guid.NewGuid()
                },
                CancellationToken.None);
            
            result.Count.ShouldBe(0);
        }
    }
}
