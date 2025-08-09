using Domain.Interfaces;
using MediatR;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;

namespace Application.Commands.Blogs.Commands
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Guid>
    {
        private readonly IBlogRepository _blog;

        public CreateBlogCommandHandler(IBlogRepository blog)
        {
            _blog = blog;
        }

        public async Task<Guid> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _blog.AddAsync(request.BlogDto, cancellationToken);
            return Guid.Empty;
        }
    }

}
