using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models;

public class Discussions
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

    [ForeignKey("UserId")]
    public string? UserId { get; set; }
    public ApplicationUsers? User { get; set; }

    public List<Comments>? Comments { get; set; }
}

