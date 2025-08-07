using System;

namespace OnlineShop.Application.DTOs
{
    public class ProductImageDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; } = default!;
        public bool IsMain { get; set; }
    }
}
