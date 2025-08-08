using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Blogs.Commands;
using OnlineShop.Application.Blogs.Dtos;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // ✅ مقداردهی موقتی تا وقتی JWT نداری
        var authorId = Guid.Parse("F809E99A-BF0D-4225-9349-F087E2EB4092");

        var command = new CreateBlogCommand
        {
            BlogDto = dto,
            AuthorId = authorId
        };

        var blogId = await _mediator.Send(command);

        return Ok(blogId);
    }
}
