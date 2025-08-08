using MediatR;

public class DeleteUserCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
