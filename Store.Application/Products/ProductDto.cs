using AutoMapper;
using Store.Application.Common.Mappings;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Products
{
    public class ProductDto: IMapWith<Product>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(productDto => productDto.ProductId,
                    opt => opt.MapFrom(product => product.ProductId))
                .ForMember(productDto => productDto.ProductName,
                    opt => opt.MapFrom(product => product.ProductName))
                .ForMember(productDto => productDto.Description,
                    opt => opt.MapFrom(product => product.Description));
        }
    }
}
