using System.ComponentModel.DataAnnotations;

namespace AzureLernen.Dtos;

public class PostDTO
{
    [Required]
    public string Title {get; set;} = default!;
    [Required]
    public string Content {get; set;} = default!;
    [Required]
    public string Author {get; set;} = default!;

    public IFormFile Image {get; set;} = default!;
}