using AzureLernen.Dtos;
using AzureLernen.Model;
using AzureLernen.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzureLernen.Controllers;

[ApiController]
[Route("/api/posts")]
public class PostController: ControllerBase
{
    private readonly IPostService postService;
    public PostController(IPostService postService) => this.postService = postService;

    [HttpGet]
    public async Task<ActionResult<List<Post>>> Get()
    {
        var posts = await this.postService.FindAll();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> Get([FromRoute] int id)
    {
        var post = await this.postService.FindOne(id);
        if(post == null) return NotFound();
        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<PostDTO>> Post([FromBody] PostDTO data)
    {
        await this.postService.Create(data);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] PostDTO data)
    {
        
        var post = await this.postService.FindOne(id);
        if(post == null) return NotFound();
        await this.postService.Update(post, data);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var post = await this.postService.FindOne(id);
        if(post == null) return NotFound();
        await this.postService.Delete(post);
        return NoContent();
    }
}