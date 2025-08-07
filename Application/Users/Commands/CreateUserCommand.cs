using MediatR;

public record CreateUserCommand(
    string FullName,
    string Email,
    string PhoneNumber,
    string Password,
    ICollection<CreateUserAddressDto>? Addresses = null
) : IRequest<Guid>;
