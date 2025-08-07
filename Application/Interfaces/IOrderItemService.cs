using OnlineShop.Application.DTOs;


namespace OnlineShop.Application.Interfaces
{
    public interface IOrderItemService
    {
        Task<List<OrderItemDto>> GetItemsByOrderIdAsync(Guid orderId);
        Task<OrderItemDto?> GetOrderItemByIdAsync(Guid orderItemId);
        Task<OrderItemDto> AddOrderItemAsync(OrderItemDto orderItemDto);
        Task<bool> UpdateOrderItemAsync(OrderItemDto orderItemDto);
        Task<bool> RemoveOrderItemAsync(Guid orderItemId);
    }
}
