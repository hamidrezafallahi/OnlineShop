using Application.Commands.Users.Commands;
using Application.Commands.Users.Dtos;
using Application.Commands.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = userId }, userId);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery { Id = id });

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        var users = await _mediator.Send(new GetUsersQuery());
        return Ok(users);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> Update(Guid id, UpdateUserCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID in URL و درخواست یکی نیستند.");

        try
        {
            var updatedUser = await _mediator.Send(command);
            return Ok(updatedUser);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"خطا در به‌روزرسانی: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteUserCommand { Id = id });
        return NoContent();
    }






}



