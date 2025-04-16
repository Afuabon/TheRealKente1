using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace TheRealKente.Controllers
{
    public class AccountController : Controller
    {
        public async Task Login(string returnUrl = "/")  
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);    
      

     
        }
        [Authorize]

        public async Task Logout()
        {

            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action("Index", "Home"))
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }


        [Authorize]

        public IActionResult UserProfile()
        {
            return View(new
            {
                User.Identity.Name,
                EmailAddress = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Email)?.Value,

            });
        }

        [Authorize]

        public IActionResult claims()

        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
