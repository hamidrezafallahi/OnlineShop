using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDbContext _context;

        public CartItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CartItem entity)
        {
            await _context.CartItems.AddAsync(entity);
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await _context.CartItems.ToListAsync();
        }

        public async Task<CartItem?> GetByIdAsync(Guid id)
        {
            return await _context.CartItems.FindAsync(id);
        }

        public async Task UpdateAsync(CartItem entity)
        {
            _context.CartItems.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.CartItems.FindAsync(id);
            if (entity != null)
                _context.CartItems.Remove(entity);
        }

        public async Task<IEnumerable<CartItem>> GetItemsByCartIdAsync(Guid cartId)
        {
            return await _context.CartItems
                                 .Where(i => i.CartId == cartId)
                                 .ToListAsync();
        }

        public async Task<CartItem?> GetItemByProductAndCartAsync(Guid cartId, Guid productId)
        {
            return await _context.CartItems
                                 .FirstOrDefaultAsync(i => i.CartId == cartId && i.ProductId == productId);
        }
    }
}
