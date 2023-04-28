using Microsoft.AspNetCore.Mvc;
using MediatR;
using SP.Commands.Application.Commands;

namespace SP.Commands.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class NewPostController : ControllerBase
{
    private readonly ILogger<NewPostController> _logger;
    private readonly ISender _sender;

    public NewPostController(ILogger<NewPostController> logger, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> NewPostAsync(NewPostCommand command)
    {   
        await _sender.Send(command);

        return StatusCode(StatusCodes.Status201Created, new NewPostResponse { Id = command.Id, Message= "New Post Created successfully" } );
    }
 }