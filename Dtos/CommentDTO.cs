using System.ComponentModel.DataAnnotations;

namespace AzureLernen.Dtos;

public class CommentDTO
{
    [Required]
    public string Title {get; set;} = default!;
    [Required]
    public string Body {get; set;} = default!;
    public int PostId {get; set;}
}