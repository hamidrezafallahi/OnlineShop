using MediatR;

public class DeleteBlogCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
