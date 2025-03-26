using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using System.Text;

namespace TheRealKente.Controllers
{
    public class AccountController : Controller
    {
        public async Task Login(string  returnUrl = "/")  
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);


            
      

     
        }

        [Authorize]

        public IActionResult UserProfile()
        {
            return View(new
            {
                Name = User.Identity.Name,
                EmailAddress = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Email)?.Value,

            });
        }
    }
}
