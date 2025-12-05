namespace AzureLernen.Model;

public class Post
{
    public int Id {get;set;}
    public string Title {get; set;} = default!;
    public string Content {get; set;} = default!;
    public string Author {get; set;} = default!;
}