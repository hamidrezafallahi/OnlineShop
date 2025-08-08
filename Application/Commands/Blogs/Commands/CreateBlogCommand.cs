using Application.Commands.Blogs.Dtos;
using MediatR;

namespace Application.Commands.Blogs.Commands
{
    public class CreateBlogCommand : IRequest<Guid>
    {
        public CreateBlogDto BlogDto { get; set; } = default!;
        public Guid AuthorId { get; set; }
    }

}
