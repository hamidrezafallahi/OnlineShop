using System;
using System.Collections.Generic;

namespace OnlineShop.Application.DTOs
{
    public class DiscountDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public decimal? DiscountAmount { get; set; }
        public float? DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        // معمولا برای جلوگیری از پیچیدگی، فقط شناسه محصولات یا تعداد محصولات را می‌آوریم.
        // اگر بخواهی لیست شناسه محصولات را بیاورم:
        public List<Guid>? ProductIds { get; set; }
    }
}
