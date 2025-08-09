using MediatR;
using Application.Commands.Categories.Dtos;

namespace Application.Commands.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateCategoryDto CategoryDto { get; set; } = null!;
    }
}
