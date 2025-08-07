using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public Discount? Discount { get; set; }
        public Guid? DiscountId { get; set; }
        public ICollection<ProductImage> Images { get; set; }=new List<ProductImage>();
    }
}
