using MediatR;

namespace Application.Commands.Brands
{
    public class CreateBrandCommand : IRequest<Guid>
    {
        public string Name { get; set; } = default!;
        public string LogoUrl { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
