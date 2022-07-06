using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Application.Common.Mappings;
using Store.Application.Interfaces;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Shops.Queries
{
    public class GetShopQuery : IRequest<List<ShopDto>>
    {

    }

    public class GetShopQueryHandler: IRequestHandler<GetShopQuery, List<ShopDto>>
    {
        private readonly IStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetShopQueryHandler(IStoreDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<List<ShopDto>> Handle(GetShopQuery request, CancellationToken cancellationToken)
        {
            var shopQuery = await _dbContext.Shops
                .ProjectTo<ShopDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return shopQuery;
        }
    }

    
}
