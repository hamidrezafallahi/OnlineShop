using OnlineShop.Application.DTOs;


namespace OnlineShop.Application.Interfaces
{
    public interface IProductImageService
    {
        Task<List<ProductImageDto>> GetImagesByProductIdAsync(Guid productId);
        Task<ProductImageDto?> GetImageByIdAsync(Guid id);
        Task<ProductImageDto> AddImageAsync(ProductImageDto productImageDto);
        Task<bool> UpdateImageAsync(ProductImageDto productImageDto);
        Task<bool> DeleteImageAsync(Guid id);
    }
}
