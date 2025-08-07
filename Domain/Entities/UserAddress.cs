using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class UserAddress
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; } = default!;
        public bool IsDefault { get; set; }
    }
}
