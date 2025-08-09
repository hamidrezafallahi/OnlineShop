using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Brands.Dtos
{
    public class UpdateBrandDto
    {
        public string Name { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
