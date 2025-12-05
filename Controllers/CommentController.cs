using AzureLernen.Dtos;
using AzureLernen.Model;
using AzureLernen.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzureLernen.Controllers;

[ApiController]
[Route("/api/comments/{postId}")]
public class CommentController: ControllerBase
{
    private readonly ICommentService commentService;
    private readonly IPostService postService;
    public CommentController(
        ICommentService commentService,
        IPostService postService
    )
    {
        this.commentService = commentService;
        this.postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Comment>>> Get([FromRoute] int postId)
    {
        var comments = await this.commentService.FindAll(postId);
        return Ok(comments);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> Get([FromRoute] int postId, [FromRoute] int id)
    {
        var foundComment = await this.commentService.FindOne(postId, id);
        if(foundComment == null)
        {
            return NotFound();
        }
        return Ok(foundComment);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromRoute] int postId, [FromBody] CommentDTO data)
    {
        var foundPost = await this.postService.FindOne(postId);
        if(foundPost == null) return NotFound();
        await this.commentService.Create(foundPost, data);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(
        [FromRoute] int postId,
        [FromRoute] int id,
        [FromBody] CommentDTO data
    )
    {
        
        var foundComment = await this.commentService.FindOne(postId, id);
        if(foundComment == null)
        {
            return NotFound();
        }
        await this.commentService.Update(foundComment, data);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(
        [FromRoute] int postId, 
        [FromRoute] int id
    )
    {
        
        var foundComment = await this.commentService.FindOne(postId, id);
        if(foundComment == null)
        {
            return NotFound();
        }
        await this.commentService.Delete(foundComment);
        return NoContent();
    }
}