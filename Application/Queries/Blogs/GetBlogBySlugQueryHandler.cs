using Application.Commands.Blogs.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces;


public class GetBlogBySlugQueryHandler : IRequestHandler<GetBlogBySlugQuery, BlogDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBlogBySlugQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BlogDto?> Handle(GetBlogBySlugQuery request, CancellationToken cancellationToken)
    {
        return await _context.Blogs
            .Where(b => b.Slug == request.Slug)
            .ProjectTo<BlogDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
