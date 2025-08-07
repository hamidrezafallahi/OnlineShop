using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        // متدهای خاص مربوط به آیتم‌های سبد خرید
        Task<IEnumerable<CartItem>> GetItemsByCartIdAsync(Guid cartId);
        Task<CartItem?> GetItemByProductAndCartAsync(Guid cartId, Guid productId);
    }
}
