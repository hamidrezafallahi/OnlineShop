using OnlineShop.Application.DTOs;

namespace OnlineShop.Application.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandDto>> GetAllBrandsAsync();
        Task<BrandDto?> GetBrandByIdAsync(Guid id);
        Task<BrandDto> CreateBrandAsync(BrandDto brandDto);
        Task<bool> UpdateBrandAsync(BrandDto brandDto);
        Task<bool> DeleteBrandAsync(Guid id);
    }
}
