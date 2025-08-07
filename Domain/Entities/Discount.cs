using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Discount
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public decimal? DiscountAmount { get; set; }
        public float? DiscountPercent { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
