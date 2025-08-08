using MediatR;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;

namespace Application.Commands.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ParentCategoryId = request.ParentCategoryId
            };
            
            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
