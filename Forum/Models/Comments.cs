namespace Forum.Models;

public class Comments
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public int DiscussionId { get; set; }
    public Discussions? Discussion { get; set; }
}
