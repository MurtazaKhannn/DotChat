using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    // This endpoint initiates the Google login flow.
    // The browser will be redirected to Google.
    [HttpGet("login")]
    public IActionResult Login(string returnUrl = "/")
    {
        string redirectUri = "http://localhost:4200/chat";

        var properties = new AuthenticationProperties { RedirectUri = redirectUri };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    // This endpoint logs the user out.
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { message = "Logged out successfully." });
    }

    // This endpoint allows the frontend to check if a user is currently logged in.
    // It returns the user's name if they have a valid auth cookie.
    [HttpGet("me")]
    public IActionResult GetCurrentUser()
    {
        if (User.Identity.IsAuthenticated)
        {
            // Return the user's name (or any other claim you want)
            return Ok(new { name = User.Identity.Name });
        }
        // If not authenticated, return 401 Unauthorized
        return Unauthorized();
    }
}