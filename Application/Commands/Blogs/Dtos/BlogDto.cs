using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Blogs.Dtos
{
    public class BlogDto
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string? ThumbnailUrl { get; set; }
        public string Slug { get; set; } = default!;

    }


}
