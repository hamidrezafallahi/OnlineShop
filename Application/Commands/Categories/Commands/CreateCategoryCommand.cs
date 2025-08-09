using MediatR;

namespace Application.Commands.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; } = default!;
        public Guid? ParentCategoryId { get; set; }
    }
}
