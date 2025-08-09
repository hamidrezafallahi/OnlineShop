using Application.Commands.Blogs.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces;

namespace Application.Commands.Blogs.Queries;

public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<BlogDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBlogsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BlogDto>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Blogs
    .ProjectTo<BlogDto>(_mapper.ConfigurationProvider)
    .ToListAsync(cancellationToken);
    }
}