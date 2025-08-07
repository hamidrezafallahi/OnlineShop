using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.Infrastructure.Repositories
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly AppDbContext _context;

        public UserAddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserAddress entity)
        {
            await _context.Addresses.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Addresses.FindAsync(id);
            if (entity != null)
            {
                _context.Addresses.Remove(entity);
            }
        }

        public async Task<IEnumerable<UserAddress>> GetAddressesByUserIdAsync(Guid userId)
        {
            return await _context.Addresses
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserAddress?> GetByIdAsync(Guid id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<UserAddress?> GetDefaultAddressByUserIdAsync(Guid userId)
        {
            return await _context.Addresses
                .FirstOrDefaultAsync(a => a.UserId == userId && a.IsDefault);
        }

        public async Task<IEnumerable<UserAddress>> GetAllAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task UpdateAsync(UserAddress entity)
        {
            _context.Addresses.Update(entity);
            await Task.CompletedTask;
        }
    }
}
