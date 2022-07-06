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
    public class GetProductQuery : IRequest<List<ProductDto>>
    {

    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductDto>>
    {
        private readonly IStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IStoreDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<List<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var productQuery = await _dbContext.Products
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return productQuery;
        }
    }
}
