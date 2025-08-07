using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly AppDbContext _context;

        public ProductImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductImage entity)
        {
            await _context.ProductImages.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.ProductImages.FindAsync(id);
            if (entity != null)
            {
                _context.ProductImages.Remove(entity);
            }
        }

        public async Task DeleteImagesByProductIdAsync(Guid productId)
        {
            var images = await _context.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToListAsync();

            _context.ProductImages.RemoveRange(images);
        }

        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _context.ProductImages.ToListAsync();
        }

        public async Task<ProductImage?> GetByIdAsync(Guid id)
        {
            return await _context.ProductImages.FindAsync(id);
        }

        public async Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(Guid productId)
        {
            return await _context.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductImage?> GetMainImageByProductIdAsync(Guid productId)
        {
            return await _context.ProductImages
                .FirstOrDefaultAsync(pi => pi.ProductId == productId && pi.IsMain);
        }

        public async Task UpdateAsync(ProductImage entity)
        {
            _context.ProductImages.Update(entity);
            await Task.CompletedTask;
        }
    }
}
