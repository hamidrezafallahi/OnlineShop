using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
        DbSet<Brand> Brands { get; }
        DbSet<Discount> Discounts { get; }
        DbSet<User> Users { get; }
        DbSet<UserAddress> Addresses { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderItem> OrderItems { get; }
        DbSet<Cart> Carts { get; }
        DbSet<CartItem> CartItems { get; }
        DbSet<ProductImage> ProductImages { get; }
        DbSet<Blog> Blogs { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

