using Microsoft.AspNetCore.Identity;

namespace Forum.Models;

public class ApplicationUsers : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
