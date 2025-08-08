using MediatR;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;

namespace Application.Commands.Brands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateBrandCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LogoUrl = request.LogoUrl,
                Description = request.Description
            };

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync(cancellationToken);

            return brand.Id;
        }
    }
}
