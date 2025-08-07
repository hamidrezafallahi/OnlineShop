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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _context;

        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OrderItem entity)
        {
            await _context.OrderItems.AddAsync(entity);
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(Guid id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public void Remove(OrderItem entity)
        {
            _context.OrderItems.Remove(entity);
        }

        public async Task UpdateAsync(OrderItem entity)
        {
            _context.OrderItems.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.OrderItems.FindAsync(id);
            if (entity != null)
            {
                _context.OrderItems.Remove(entity);
            }
        }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(Guid orderId)
        {
            return await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<decimal> CalculateTotalPriceAsync(Guid orderId)
        {
            return await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .SumAsync(oi => oi.UnitPrice * oi.Quantity);
        }
    }
}
