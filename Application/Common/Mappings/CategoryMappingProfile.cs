using AutoMapper;
using OnlineShop.Domain.Entities;
using Application.Commands.Categories.Dtos;

namespace Application.Common.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>();

        }
    }
}
