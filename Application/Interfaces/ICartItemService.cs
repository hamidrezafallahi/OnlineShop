using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Carts.Dtos;

namespace OnlineShop.Application.Interfaces
{
    public interface ICartItemService
    {
        Task<List<CartItemDto>> GetCartItemsByCartIdAsync(Guid cartId);
        Task<CartItemDto?> GetCartItemByIdAsync(Guid cartItemId);
        Task<CartItemDto> AddCartItemAsync(CartItemDto cartItemDto);
        Task<bool> UpdateCartItemAsync(CartItemDto cartItemDto);
        Task<bool> RemoveCartItemAsync(Guid cartItemId);
    }
}
