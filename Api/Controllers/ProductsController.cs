using Application.Commands.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await _mediator.Send(command);

        return Ok(id);
    }
}
