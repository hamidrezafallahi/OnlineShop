using Application.Commands.Users.Dtos;
using MediatR;

namespace Application.Commands.Users.Queries;

public class GetUsersQuery : IRequest<List<UserDto>> { }

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public Guid Id { get; set; }
}
