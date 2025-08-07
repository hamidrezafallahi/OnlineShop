
using OnlineShop.Application.DTOs;

namespace OnlineShop.Application.Interfaces
{
    public interface ICartService
    {
        Task<CartDto?> GetCartByUserIdAsync(Guid userId);
        Task<CartDto> CreateCartAsync(CartDto cartDto);
        Task<bool> UpdateCartAsync(CartDto cartDto);
        Task<bool> DeleteCartAsync(Guid cartId);

        // عملیات اختصاصی برای اضافه کردن آیتم به سبد
        Task<bool> AddItemToCartAsync(Guid userId, CartItemDto cartItemDto);

        // حذف آیتم از سبد
        Task<bool> RemoveItemFromCartAsync(Guid userId, Guid cartItemId);

        // بروزرسانی تعداد آیتم در سبد
        Task<bool> UpdateItemQuantityAsync(Guid userId, Guid cartItemId, int quantity);
    }
}
