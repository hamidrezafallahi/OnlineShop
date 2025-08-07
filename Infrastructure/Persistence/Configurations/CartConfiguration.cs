using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Persistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);

            // رابطه با کاربر (User)
            builder.HasOne(c => c.User)
                   .WithOne(u => u.Cart) // فرض می‌کنیم هر کاربر یک سبد دارد
                   .HasForeignKey<Cart>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // وقتی کاربر حذف شود، سبد هم حذف شود

            // رابطه با آیتم‌های سبد
            builder.HasMany(c => c.Items)
                   .WithOne(i => i.Cart)
                   .HasForeignKey(i => i.CartId)
                   .OnDelete(DeleteBehavior.Cascade); // حذف سبد، آیتم‌ها هم حذف شوند
        }
    }
}
