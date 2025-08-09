using Application.Commands.Blogs.Dtos;
using MediatR;

public class GetBlogBySlugQuery : IRequest<BlogDto?>
{
    public string Slug { get; set; } = null!;
}
