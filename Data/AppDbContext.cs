using AzureLernen.Model;
using Microsoft.EntityFrameworkCore;

namespace AzureLernen.Data;

public class AppDbContext: DbContext
{
    public DbSet<Post> Post {get; set;}
    public DbSet<Comment> Comment {get; set;}
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
}