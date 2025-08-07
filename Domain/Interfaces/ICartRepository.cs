using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces;

public interface ICartRepository : IRepository<Cart>
{
    // متدهای اختصاصی Cart می‌تونه اینجا اضافه بشه
    Task<Cart?> GetUserCartAsync(Guid userId);
}
