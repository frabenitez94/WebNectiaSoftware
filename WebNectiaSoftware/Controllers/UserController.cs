using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateUser(string userName, string password)
    {
        var user = new IdentityUser { UserName = userName };
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
            return Ok("Usuario creado");
        return BadRequest(result.Errors);
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }
}
