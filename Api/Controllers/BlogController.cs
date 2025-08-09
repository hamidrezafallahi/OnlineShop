using Application.Commands.Blogs.Commands;
using Application.Commands.Blogs.Dtos;
using Application.Commands.Blogs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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


    [HttpGet]
    public async Task<ActionResult<List<BlogDto>>> GetBlogs()
    {
        var result = await _mediator.Send(new GetBlogsQuery());
        return Ok(result);
    }

    //[HttpGet("{id}")]
    //public async Task<ActionResult<BlogDto>> GetBlogById(Guid id)
    //{
    //    var result = await _mediator.Send(new GetBlogByIdQuery { Id = id });
    //    if (result == null)
    //        return NotFound();

    //    return Ok(result);
    //}



    [HttpGet("{slug}")]
    public async Task<ActionResult<BlogDto>> GetBlogBySlug(string slug)
    {
        var result = await _mediator.Send(new GetBlogBySlugQuery { Slug = slug });
        if (result == null)
            return NotFound();

        return Ok(result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(Guid id, [FromBody] UpdateBlogDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new UpdateBlogCommand { Id = id, BlogDto = dto };
        var result = await _mediator.Send(command);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(Guid id)
    {
        var command = new DeleteBlogCommand { Id = id };
        var result = await _mediator.Send(command);

        if (!result)
            return NotFound();

        return NoContent();
    }



}
