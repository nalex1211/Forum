namespace Forum.Models;

public class Discussions
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public string UserId { get; set; }
    public int LikeCount { get; set; }
    public int ReportCount { get; set; }
}
