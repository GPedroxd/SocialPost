using MediatR;
using Microsoft.AspNetCore.Mvc;
using SP.Queries.Application.Queries;

namespace SP.Queries.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PostController : ControllerBase
{
    private readonly ISender _serder;

    public PostController(ISender sender)
        => _serder = sender;

    [HttpGet]
    public async Task<IActionResult> GetAllPostAsync()
    {
        var response = await _serder.Send(new GetPostsQuery());

        if(response.SuccessResponse is null || response.SuccessResponse.Count == 0)
            return NoContent();

        return Ok(response);
    }

    [HttpGet("{postid}")]
    public async Task<IActionResult> GetPostByIdAsync(Guid postid)
    {
        var command = new GetPostByIdQuery()
        {
            PostId = postid
        };

        var response = await _serder.Send(command);

        if(!response.Success || response.SuccessResponse is null)
            return NotFound();

        return Ok(response);
    }

    [HttpGet("{postid}/comments")]
    public async Task<IActionResult> GetPostCommentsAsync(Guid postid)
    {
        var command = new GetPostCommentsQuery()
        {
            PostId = postid
        };

        var response = await _serder.Send(command);

        if(response.SuccessResponse is null || response.SuccessResponse.Count == 0)
            return NoContent();

        return Ok(response);
    }

    [HttpGet("byauthor/{author}")]
    public async Task<IActionResult> GetPostsByAuthorAsync(string author)
    {
        var command = new GetPostsByAuthorQuery()
        {
            Author = author
        };

        var response = await _serder.Send(command);

        if(response.SuccessResponse is null || response.SuccessResponse.Count == 0)
            return NoContent();

        return Ok(response);
    }
}