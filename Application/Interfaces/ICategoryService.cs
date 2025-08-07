
using OnlineShop.Application.DTOs;

namespace OnlineShop.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(Guid id);
        Task<CategoryDto> CreateAsync(CategoryDto categoryDto);
        Task<bool> UpdateAsync(CategoryDto categoryDto);
        Task<bool> DeleteAsync(Guid id);

        // برای گرفتن دسته‌بندی‌های فرزند یک دسته‌بندی
        Task<List<CategoryDto>> GetSubCategoriesAsync(Guid parentCategoryId);

        // اگر بخواهی می‌توانی متدهای فیلتر و جستجو را اضافه کنی
    }
}
