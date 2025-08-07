using OnlineShop.Application.DTOs;

namespace OnlineShop.Application.Interfaces
{
    public interface IUserAddressService
    {
        Task<List<UserAddressDto>> GetAddressesByUserIdAsync(Guid userId);
        Task<UserAddressDto?> GetAddressByIdAsync(Guid id);
        Task<UserAddressDto> CreateAddressAsync(UserAddressDto addressDto);
        Task<bool> UpdateAddressAsync(UserAddressDto addressDto);
        Task<bool> DeleteAddressAsync(Guid id);

        // متد برای تنظیم آدرس پیش‌فرض
        Task<bool> SetDefaultAddressAsync(Guid userId, Guid addressId);
    }
}
