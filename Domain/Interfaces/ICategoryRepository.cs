using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    // گرفتن زیر‌دسته‌ها بر اساس آی‌دی پدر
    Task<IEnumerable<Category>> GetSubCategoriesAsync(Guid parentCategoryId);

    // گرفتن همه‌ی دسته‌بندی‌های ریشه‌ای (بدون پدر)
    Task<IEnumerable<Category>> GetRootCategoriesAsync();
}
