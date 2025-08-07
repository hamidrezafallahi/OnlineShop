using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Persistence.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            // رابطه با Cart
            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.Items)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade); // حذف سبد، آیتم‌ها هم حذف شوند

            // رابطه با Product
            builder.HasOne(ci => ci.Product)
                   .WithMany() // فرض بر اینه که Product رابطه معکوس با CartItem ندارد
                   .HasForeignKey(ci => ci.ProductId)
                   .OnDelete(DeleteBehavior.Restrict); // حذف محصول، آیتم‌ها حذف نشوند

            builder.Property(ci => ci.Quantity)
                   .IsRequired();

            builder.Property(ci => ci.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
        }
    }
}
