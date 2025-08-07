using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Domain.Entities
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl   { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }=new List<Product>();

    }
}
