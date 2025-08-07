using MediatR;
using OnlineShop.Application.Blogs.Dtos;

namespace OnlineShop.Application.Blogs.Commands
{
    public class CreateBlogCommand : IRequest<Guid>
    {
        public CreateBlogDto BlogDto { get; set; } = default!;
        public Guid AuthorId { get; set; }
    }

}
