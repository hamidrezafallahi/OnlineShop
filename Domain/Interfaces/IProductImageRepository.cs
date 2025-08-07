using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        // دریافت همه تصاویر مربوط به یک محصول خاص
        Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(Guid productId);

        // دریافت تصویر اصلی یک محصول
        Task<ProductImage?> GetMainImageByProductIdAsync(Guid productId);

        // حذف همه تصاویر یک محصول (مثلاً هنگام حذف محصول)
        Task DeleteImagesByProductIdAsync(Guid productId);
    }
}
