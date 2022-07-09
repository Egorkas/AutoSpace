using AutoMapper;
using Store.Application.Common.Mappings;
using Store.Domain;

namespace Store.Application.Shops.Queries
{
    public class ShopDto : IMapWith<Shop>
    {
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Shop, ShopDto>()
                .ForMember(shopDto => shopDto.ShopId,
                    opt => opt.MapFrom(shop => shop.ShopId))
                .ForMember(shopDto => shopDto.ShopName,
                    opt => opt.MapFrom(shop => shop.ShopName))
                .ForMember(shopDto => shopDto.ShopAddress,
                    opt => opt.MapFrom(shop => shop.ShopAddress))
                .ForMember(shopDto => shopDto.OpeningTime,
                    opt => opt.MapFrom(shop => TimeOnly.FromDateTime(shop.OpeningTime)))
                .ForMember(shopDto => shopDto.ClosingTime,
                    opt => opt.MapFrom(shop => TimeOnly.FromDateTime(shop.ClosingTime)));
        }
    }
}
