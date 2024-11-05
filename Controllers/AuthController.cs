using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpGet("login")]
    public IActionResult Login(string returnUrl = null)
    {
        var redirectUrl = Url.Action(nameof(LoginCallback), "Auth", new { returnUrl });
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("signin-google")]
    public async Task<IActionResult> LoginCallback(string returnUrl = null)
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (!result.Succeeded)
        {
            return RedirectToAction("Login");
        }


        return LocalRedirect(returnUrl ?? "/");
    }
}
