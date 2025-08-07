using OnlineShop.Application.DTOs;
using OnlineShop.Domain.Enums;


namespace OnlineShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetOrdersByUserIdAsync(Guid userId);
        Task<OrderDto?> GetOrderByIdAsync(Guid orderId);
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
        Task<bool> UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
        Task<bool> CancelOrderAsync(Guid orderId);
    }
}
