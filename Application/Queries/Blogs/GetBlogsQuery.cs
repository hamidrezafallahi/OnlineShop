using Application.Commands.Blogs.Dtos;
using MediatR;

namespace Application.Commands.Blogs.Queries;

public class GetBlogsQuery : IRequest<List<BlogDto>> { }

public class GetBlogByIdQuery : IRequest<BlogDto?>
{
    public Guid Id { get; set; }
}
