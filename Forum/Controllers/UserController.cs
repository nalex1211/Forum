using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IdentityDBContext _db;

    public UserController(IdentityDBContext db, UserManager<ApplicationUsers> userManager)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<ApplicationUsers>>> GetUsers()
    {
        return await _db.Users.ToListAsync();
    }
   
}
