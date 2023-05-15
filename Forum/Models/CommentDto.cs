namespace Forum.Models;

public class CommentDto
{
    public string Text { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
