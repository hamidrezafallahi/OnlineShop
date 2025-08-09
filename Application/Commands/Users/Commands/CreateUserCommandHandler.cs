using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Interfaces;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repo;
    private readonly IPasswordHasher<User> _passwordHasher;

    public CreateUserCommandHandler(
        IPasswordHasher<User> passwordHasher, IUserRepository repo)
    {
        _passwordHasher = passwordHasher;
        _repo = repo;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // چک کردن ایمیل تکراری
        var existingUser = await _repo.Table().AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (existingUser != null)
            throw new Exception("A user with this email already exists.");

        // ساخت یوزر
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
        };

        // هش کردن رمز عبور
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        // اضافه کردن آدرس‌ها (در صورت وجود)
        if (request.Addresses != null && request.Addresses.Any())
        {
            user.Addresses = request.Addresses.Select(addressDto => new UserAddress
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                City = addressDto.City,
                State = addressDto.State,
                PostalCode = addressDto.PostalCode,
                FullAddress = addressDto.FullAddress,
                IsDefault = addressDto.IsDefault
            }).ToList();
        }

        // اضافه به دیتابیس و ذخیره
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
