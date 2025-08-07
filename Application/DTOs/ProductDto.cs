using System;
using System.Collections.Generic;

namespace OnlineShop.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? DiscountId { get; set; }

        // برای تصاویر، معمولاً فقط URL یا شناسه تصاویر آورده می‌شود:
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
