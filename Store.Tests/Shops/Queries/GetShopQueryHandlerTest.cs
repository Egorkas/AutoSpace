using AutoMapper;
using Shouldly;
using Store.Application.Shops.Queries;
using Store.Persistence;
using Store.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Shops.Queries
{
    [Collection("QueryCollection")]
    public class GetShopQueryHandlerTest
    {
        private readonly StoreDbContext Context;
        private readonly IMapper Mapper;
        public GetShopQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetShopQueryHandler_Success()
        {
            //Arrange
            var handler = new GetShopQueryHandler(Context, Mapper);
            
            //Act
            var result = await handler.Handle(
                new GetShopQuery(),
                CancellationToken.None
                );

            //Assert
            result.ShouldBeOfType<List<ShopDto>>();
            result.Count.ShouldBe(1);
        }
    }
}
