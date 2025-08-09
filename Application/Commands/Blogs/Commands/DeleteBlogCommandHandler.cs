using MediatR;
using OnlineShop.Application.Common.Interfaces;

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteBlogCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _context.Blogs.FindAsync(new object[] { request.Id }, cancellationToken);
        if (blog == null)
            return false;

        _context.Blogs.Remove(blog);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
