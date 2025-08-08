
namespace OnlineShop.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<UserAddress> Addresses { get; set; } = new List<UserAddress>();
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();

        public Cart? Cart { get; set; }
    }
}
