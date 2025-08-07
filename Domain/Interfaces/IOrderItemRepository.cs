using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        // گرفتن همه آیتم‌های یک سفارش خاص
        Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(Guid orderId);

        // محاسبه مجموع قیمت آیتم‌های یک سفارش
        Task<decimal> CalculateTotalPriceAsync(Guid orderId);
    }
}
