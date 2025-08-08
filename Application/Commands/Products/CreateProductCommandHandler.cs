using MediatR;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;

namespace Application.Commands.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Inventory = request.Inventory,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                DiscountId = request.DiscountId
            };

            _context.Products.Add(product);

            // فرض می‌کنیم تصاویر در جدول جداگانه یا فیلدهای مرتبط ذخیره می‌شوند.
            // اگر موجودیت ImageUrls نداری، باید اضافه کنی.
            // فرض کنیم موجودیت ProductImage داریم:

            foreach (var url in request.ImageUrls)
            {
                var image = new ProductImage
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    ImageUrl= url,
                    IsMain=true
                };
                _context.ProductImages.Add(image);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}