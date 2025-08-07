using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        // دریافت محصولات بر اساس دسته‌بندی
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(Guid categoryId);

        // دریافت محصولات بر اساس برند
        Task<IEnumerable<Product>> GetProductsByBrandIdAsync(Guid brandId);

        // دریافت محصولات دارای تخفیف فعال
        Task<IEnumerable<Product>> GetDiscountedProductsAsync();

        // جستجوی محصول با نام
        Task<IEnumerable<Product>> SearchByNameAsync(string keyword);
    }
}
