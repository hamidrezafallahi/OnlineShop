using MediatR;
using OnlineShop.Application.Common.Interfaces;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);

        if (user == null)
            throw new KeyNotFoundException("User not found");

        _context.Users.Remove(user);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
