using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Persistence.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Title)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(d => d.DiscountAmount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(d => d.DiscountPercent)
                   .HasColumnType("float");

            builder.Property(d => d.StartDate)
                   .IsRequired();

            builder.Property(d => d.EndDate)
                   .IsRequired();

            builder.Property(d => d.IsActive)
                   .IsRequired();

            // رابطه با محصولات
            builder.HasMany(d => d.Products)
                   .WithOne(p => p.Discount)
                   .HasForeignKey(p => p.DiscountId)
                   .OnDelete(DeleteBehavior.SetNull); // وقتی تخفیف حذف شد، مقدار در محصول Null شود
        }
    }
}
