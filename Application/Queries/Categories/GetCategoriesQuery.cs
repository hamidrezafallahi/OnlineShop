using MediatR;
using Application.Commands.Categories.Dtos;

namespace Application.Commands.Categories.Queries;

public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
}

public class GetCategoryByIdQuery : IRequest<CategoryDto?>
{
    public Guid Id { get; set; }
}
