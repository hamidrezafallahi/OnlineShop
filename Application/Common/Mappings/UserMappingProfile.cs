using Application.Commands.Blogs.Dtos;
using Application.Commands.Users.Dtos;
using Application.Commands.Orders.Dtos;
using AutoMapper;
using OnlineShop.Domain.Entities;
using Application.Commands.Carts.Dtos;
namespace Application.Common.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(o => o.Id)))
            .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));

        CreateMap<UserAddress, UserAddressDto>();
        //CreateMap<Order, OrderDto>()
        //    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        //CreateMap<OrderItem, OrderItemDto>();
        //CreateMap<Blog, BlogDto>();
        //CreateMap<Cart, CartDto>();
    }
}
