using Application.Commands.Brands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Brands
{
    public class GetAllBrandsQuery : IRequest<List<BrandDto>> { }

    public class GetBrandByIdQuery : IRequest<BrandDto?>
    {
        public Guid Id { get; set; }
    }
}
