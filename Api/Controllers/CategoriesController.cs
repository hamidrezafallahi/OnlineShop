using Application.Commands.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await _mediator.Send(command);

        return Ok(id);
    }
}
