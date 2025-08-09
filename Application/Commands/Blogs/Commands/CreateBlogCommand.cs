using Application.Commands.Blogs.Dtos;
using MediatR;
using OnlineShop.Domain.Entities;

namespace Application.Commands.Blogs.Commands
{
    public class CreateBlogCommand : IRequest<Guid>
    {
        public Blog BlogDto { get; set; } = default!;
        public Guid AuthorId { get; set; }
    }

}
