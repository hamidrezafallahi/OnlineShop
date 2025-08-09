using MediatR;
using Application.Commands.Brands.Dtos;

namespace Application.Commands.Brands.Commands
{
    public class UpdateBrandCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateBrandDto BrandDto { get; set; } = null!;
    }
}
