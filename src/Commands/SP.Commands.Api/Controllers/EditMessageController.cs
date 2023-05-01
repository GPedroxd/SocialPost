
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SP.Commands.Application.Commands;
using SP.Common.Dtos;

namespace SP.Commands.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EditMessageController : ControllerBase
{
    private readonly ILogger<EditMessageController> _logger;
    private readonly ISender _sender;

    public EditMessageController(ILogger<EditMessageController> logger, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> EditMessageAsync(Guid id, EditPostCommand command)
    {
        command.Id = id;
        await _sender.Send(command);

        return Ok(new BaseResponse(){ 
            Message = "Edit message completed successfully"
        });
    }
}