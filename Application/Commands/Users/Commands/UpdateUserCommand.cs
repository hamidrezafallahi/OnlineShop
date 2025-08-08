using MediatR;
using Application.Commands.Users.Dtos;

namespace Application.Commands.Users.Commands;

public class UpdateUserCommand : IRequest<UserDto>
{
    public Guid Id { get; set; }  // بهتره Guid باشه چون Id یوزر شما Guid هست
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    // در صورت نیاز می‌توانید فیلدهای دیگر را هم اضافه کنید
}
