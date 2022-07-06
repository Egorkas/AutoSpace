using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Products
{
    public class GetProductByShopIdQuery : IRequest<List<ProductDto>>
    {
        public Guid ShopId { get; set; }
    }

    public class GetProductByShopIdQueryHandler : IRequestHandler<GetProductByShopIdQuery, List<ProductDto>>
    {
        private readonly IStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductByShopIdQueryHandler(IStoreDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public Task<List<ProductDto>> Handle(GetProductByShopIdQuery request, CancellationToken cancellationToken)
        {
            var productQuery = _dbContext.Products
                .Where(item => item.Shops
                    .Any(o => o.ShopId == request.ShopId))
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return productQuery;
        }
    }
}
