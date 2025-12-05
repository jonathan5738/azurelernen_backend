using AzureLernen.Data;
using AzureLernen.Dtos;
using AzureLernen.Model;
using Microsoft.EntityFrameworkCore;

namespace AzureLernen.Services;

public class PostService: IPostService
{
    private readonly AppDbContext _context;
    public PostService(AppDbContext context) => this._context = context;

    public async Task<List<Post>> FindAll()
    {
        return await this._context.Post.ToListAsync();
    }
    public async Task<Post?> FindOne(int id)
    {
        var foundPost = await this._context.Post
          .FirstOrDefaultAsync(post => post.Id == id);
        return foundPost;
    }
    
    public async Task Create(PostDTO data)
    {
        var newPost = new Post {
            Title = data.Title,
            Content = data.Content, 
            Author = data.Author
        };
        this._context.Post.Add(newPost);
        await this._context.SaveChangesAsync();
    }

    public async Task Update(Post post, PostDTO data)
    {
        post.Title = data.Title;
        post.Content = data.Content;
        post.Author = data.Author;

        await this._context.SaveChangesAsync();
    }

    public async Task Delete(Post post)
    {
        this._context.Post.Remove(post);
        await this._context.SaveChangesAsync();
    }
}