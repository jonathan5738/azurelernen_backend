using AzureLernen.Data;
using AzureLernen.Dtos;
using AzureLernen.Model;
using Microsoft.EntityFrameworkCore;

namespace AzureLernen.Services;

public class CommentService: ICommentService
{
    private readonly AppDbContext _context;
    public CommentService(AppDbContext context) => this._context = context;

    public async Task<List<Comment>> FindAll(int postId)
    {
        var comments = await this._context
        .Comment.Where(c => c.PostId == postId)
        .ToListAsync();
        return comments;
    }

    public async Task<Comment?> FindOne(int postId, int commentId)
    {
        var comment = await this._context.Comment
        .Where(c => c.PostId == postId)
        .FirstOrDefaultAsync(c => c.Id == commentId);
        return comment;
    }

    public async Task Create(Post post, CommentDTO data)
    {
        var comment = new Comment {Title = data.Title, Body = data.Body};
        comment.Post = post;
        this._context.Comment.Add(comment);
        await this._context.SaveChangesAsync();
    }

    public async Task Update(Comment comment, CommentDTO data)
    {
        comment.Title = data.Title;
        comment.Body = data.Body;

        await this._context.SaveChangesAsync();
    }

    public async Task Delete(Comment comment)
    {
        this._context.Comment.Remove(comment);
        await this._context.SaveChangesAsync();
    }
}