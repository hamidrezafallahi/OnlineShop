using MediatR;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;

namespace Application.Commands.Blogs.Commands
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateBlogCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog
            {
                Id = Guid.NewGuid(),
                Title = request.BlogDto.Title,
                Slug = request.BlogDto.Slug,
                Content = request.BlogDto.Content,
                ThumbnailUrl = request.BlogDto.ThumbnailUrl,
                AuthorId = request.AuthorId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync(cancellationToken);

            return blog.Id;
        }
    }

}
