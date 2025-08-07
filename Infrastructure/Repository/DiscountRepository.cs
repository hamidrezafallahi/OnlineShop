using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly AppDbContext _context;

        public DiscountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Discount entity)
        {
            await _context.Discounts.AddAsync(entity);
        }

        public async Task<IEnumerable<Discount>> GetAllAsync()
        {
            return await _context.Discounts.ToListAsync();
        }

        public async Task<Discount?> GetByIdAsync(Guid id)
        {
            return await _context.Discounts.FindAsync(id);
        }

        public void Remove(Discount entity)
        {
            _context.Discounts.Remove(entity);
        }

        public Task UpdateAsync(Discount entity)
        {
            _context.Discounts.Update(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount is not null)
                _context.Discounts.Remove(discount);
        }

        public async Task<IEnumerable<Discount>> GetActiveDiscountsAsync()
        {
            var now = DateTime.UtcNow;
            return await _context.Discounts
                .Where(d => d.StartDate <= now && d.EndDate >= now)
                .ToListAsync();
        }

        public async Task<bool> IsDiscountValidAsync(Guid discountId)
        {
            var now = DateTime.UtcNow;
            return await _context.Discounts
                .AnyAsync(d => d.Id == discountId && d.StartDate <= now && d.EndDate >= now);
        }

        public async Task<Discount?> GetDiscountByProductIdAsync(Guid productId)
        {
            return await _context.Discounts
                .FirstOrDefaultAsync(d => d.Id == productId);
        }
    }
}
