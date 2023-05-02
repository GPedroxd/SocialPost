using MediatR;
using Microsoft.AspNetCore.Mvc;
using SP.Commands.Application.Commands;
using SP.Common.Dtos;

namespace SP.Commands.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly ISender _sender;

    public PostController(ILogger<PostController> logger, ISender sender)
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

    [HttpPut("{postid}")]
    public async Task<IActionResult> EditMessageAsync(Guid postid, EditPostCommand command)
    {
        command.Id = postid;
        await _sender.Send(command);

        return Ok(new BaseResponse(){ 
            Message = "Edit message successfully"
        });
    }

    [HttpPost("{postid}/like")]
    public async Task<IActionResult> LikePostAsync(Guid postid)
    {
        var command = new LikePostCommand(){ Id = postid };

        await _sender.Send(command);

        return Ok(new BaseResponse(){ 
            Message = "Post Like successfully"
        });
    }

    [HttpPost("{postid}/comment")]
    public async Task<IActionResult> AddCommentAsync(Guid postid, AddCommentCommand command)
    {
        await _sender.Send(command);

        return Ok(new BaseResponse(){ 
            Message = "Comment Added successfully"
        });
    }

    [HttpPut("{postid}/comment/{commentid}")]
    public async Task<IActionResult> EditCommentAsync(Guid postid, Guid commentid, EditCommentCommand command)
    {
        await _sender.Send(command);

        return Ok(new BaseResponse(){ 
            Message = "Comment Edited successfully"
        });
    }

    [HttpDelete("{postid}/comment/{commentid}")]
    public async Task<IActionResult> RemoveCommentAsync(Guid postid, Guid commentid, RemoveCommentCommand command)
    {
        await _sender.Send(command);

        return Ok(new BaseResponse(){ 
            Message = "Comment Edited successfully"
        });
    }

    [HttpDelete("{postid}")]
    public async Task<IActionResult> DeletePostAsync(Guid postid, DeletePostCommand command)
    {
        await _sender.Send(command);

        return NoContent();
    }
}