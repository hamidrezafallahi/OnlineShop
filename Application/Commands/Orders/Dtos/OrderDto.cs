
using OnlineShop.Domain.Enums;
namespace Application.Commands.Orders.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        // آیتم‌های سفارش رو هم می‌تونیم به صورت لیست DTO های جداگانه نگه داریم:
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }

    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
