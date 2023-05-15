using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models;

public class Comments
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public Discussions? Discussions { get; set; }
}
