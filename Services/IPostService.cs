using AzureLernen.Dtos;
using AzureLernen.Model;
namespace AzureLernen.Services;

public interface IPostService
{
    public  Task<List<Post>> FindAll();
    public  Task<Post?> FindOne(int id);
    
    public  Task Create(PostDTO data);

    public  Task Update(Post post, PostDTO data);

    public  Task Delete(Post post);
}