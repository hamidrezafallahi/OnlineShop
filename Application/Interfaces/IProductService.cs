using OnlineShop.Application.DTOs;


namespace OnlineShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(Guid id);
        Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId);
        Task<List<ProductDto>> GetProductsByBrandAsync(Guid brandId);
        Task<List<ProductDto>> GetDiscountedProductsAsync();
        Task<ProductDto> CreateProductAsync(ProductDto productDto);
        Task<bool> UpdateProductAsync(ProductDto productDto);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
