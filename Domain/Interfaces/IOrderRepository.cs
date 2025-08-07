using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        // گرفتن سفارش‌های یک کاربر
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);

        // گرفتن سفارش با آیتم‌ها (برای نمایش جزئیات کامل سفارش)
        Task<Order?> GetOrderWithItemsAsync(Guid orderId);

        // گرفتن سفارش‌های باز (پرداخت نشده یا در حال پردازش)
        Task<IEnumerable<Order>> GetOpenOrdersAsync();
    }
}
