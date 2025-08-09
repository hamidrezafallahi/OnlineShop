using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBlogRepository
    {
        Task<int> AddAsync(Blog blog, CancellationToken cancellationToken);
    }
}
