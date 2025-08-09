using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interfaces;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateBlogCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _context.Blogs.FindAsync(new object[] { request.Id }, cancellationToken);
        if (blog == null)
            return false;

        // مپ کردن فیلدها از DTO به موجودیت
        _mapper.Map(request.BlogDto, blog);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
