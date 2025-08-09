using AutoMapper;
using OnlineShop.Domain.Entities;
using Application.Commands.Blogs.Dtos;

namespace Application.Common.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, BlogDto>();

        }
    }
}
