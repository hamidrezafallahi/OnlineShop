using Application.Commands.Brands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBrandCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await _mediator.Send(command);

        return Ok(id);
    }
}
