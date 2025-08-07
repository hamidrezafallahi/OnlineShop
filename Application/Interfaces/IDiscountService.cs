
using OnlineShop.Application.DTOs;

namespace OnlineShop.Application.Interfaces
{
    public interface IDiscountService
    {
        Task<List<DiscountDto>> GetAllDiscountsAsync();
        Task<DiscountDto?> GetDiscountByIdAsync(Guid id);
        Task<DiscountDto> CreateDiscountAsync(DiscountDto discountDto);
        Task<bool> UpdateDiscountAsync(DiscountDto discountDto);
        Task<bool> DeleteDiscountAsync(Guid id);

        // متدهای اختصاصی مثلا گرفتن تخفیف‌های فعال
        Task<List<DiscountDto>> GetActiveDiscountsAsync(DateTime currentDate);
    }
}
