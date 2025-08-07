using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces
{
    public interface IUserAddressRepository : IRepository<UserAddress>
    {
        // گرفتن همه آدرس‌های یک کاربر
        Task<IEnumerable<UserAddress>> GetAddressesByUserIdAsync(Guid userId);

        // گرفتن آدرس پیش‌فرض یک کاربر
        Task<UserAddress?> GetDefaultAddressByUserIdAsync(Guid userId);
    }
}
