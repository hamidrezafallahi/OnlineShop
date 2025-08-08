using Application.Commands.Users.Dtos;
using Application.Commands.Orders.Dtos;

namespace OnlineShop.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<bool> UpdateUserAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(Guid id);

        // متد اختصاصی برای گرفتن سفارشات کاربر
        Task<List<OrderDto>> GetUserOrdersAsync(Guid userId);

        // متد اختصاصی برای گرفتن آدرس‌های کاربر
        Task<List<UserAddressDto>> GetUserAddressesAsync(Guid userId);

        // متد احراز هویت یا ورود (مثال ساده)
        Task<UserDto?> AuthenticateAsync(string email, string password);

        // متدهای مربوط به تغییر رمز عبور، ریست پسورد و ... را می‌توان اضافه کرد
    }
}
