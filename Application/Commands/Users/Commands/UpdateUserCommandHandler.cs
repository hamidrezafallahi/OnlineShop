using Application.Commands.Users.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces;
namespace Application.Commands.Users.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
            throw new KeyNotFoundException("User not found");

        // به‌روزرسانی فیلدها
        user.FullName = request.FullName;
        user.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;

        // اگر لازم بود، می‌توانید سایر فیلدها یا مجموعه‌ها را هم آپدیت کنید

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserDto>(user);
    }
}
