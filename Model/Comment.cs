namespace AzureLernen.Model;

public class Comment
{
    public int Id {get; set;}
    public string Title {get; set;} = default!;
    public string Body {get; set;} = default!;

    public int PostId {get; set;}
    public Post Post {get; set;} = default!;
}