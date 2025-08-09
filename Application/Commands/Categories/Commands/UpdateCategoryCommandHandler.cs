using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interfaces;
using Application.Commands.Categories.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (category == null)
                return false;

            // مپ کردن تغییرات
            _mapper.Map(request.CategoryDto, category);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
