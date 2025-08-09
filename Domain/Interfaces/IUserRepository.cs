using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        // دریافت کاربر با ایمیل (مثلاً برای لاگین)
        Task<User?> GetByEmailAsync(string email);
        IQueryable<User> Table();

        // دریافت کاربر با شماره تلفن
        Task<User?> GetByPhoneNumberAsync(string phoneNumber);

        // دریافت کاربر همراه با آدرس‌ها و سبد خرید
        Task<User?> GetUserWithDetailsAsync(Guid userId);
    }
}
