using MediatR;

public class UpdateBlogCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public UpdateBlogDto BlogDto { get; set; } = null!;
}

public class UpdateBlogDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public string Slug { get; set; } = null!;

  }
