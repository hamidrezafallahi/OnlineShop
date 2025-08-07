using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces;

public interface IDiscountRepository : IRepository<Discount>
{
    // گرفتن تخفیف‌های فعال
    Task<IEnumerable<Discount>> GetActiveDiscountsAsync();

    // بررسی اینکه یک تخفیف خاص در تاریخ فعلی معتبر هست یا نه
    Task<bool> IsDiscountValidAsync(Guid discountId);

    // گرفتن تخفیف‌های مرتبط با محصول خاص (در صورت نیاز)
    Task<Discount?> GetDiscountByProductIdAsync(Guid productId);
}
