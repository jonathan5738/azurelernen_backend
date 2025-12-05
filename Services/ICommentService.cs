using AzureLernen.Dtos;
using AzureLernen.Model;

namespace AzureLernen.Services;

public interface ICommentService
{
    public  Task<List<Comment>> FindAll(int postId);

    public  Task<Comment?> FindOne(int postId, int commentId);

    public  Task Create(Post post, CommentDTO data);

    public  Task Update(Comment comment, CommentDTO data);

    public  Task Delete(Comment comment);
}