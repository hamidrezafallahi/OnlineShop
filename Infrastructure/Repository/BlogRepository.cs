using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;
using System.Threading;

namespace Infrastructure.Repository;

public class BlogRepository : IBlogRepository
{
    private readonly IApplicationDbContext _context;

    public BlogRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> AddAsync(Blog blog, CancellationToken cancellationToken)
    {
        _context.Blogs.Add(blog);
        var res = _context.SaveChangesAsync(cancellationToken);
        return res;
    }
}
