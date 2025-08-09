using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Brands.Commands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FindAsync(new object[] { request.Id }, cancellationToken);
            if (brand == null)
                return false;

            _mapper.Map(request.BrandDto, brand);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
