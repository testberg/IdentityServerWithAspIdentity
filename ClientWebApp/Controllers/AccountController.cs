using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*
         *  Called when requesting to sign up or sign in
         */
        public ActionResult SignUpSignIn(string redirectUrl)
        {
            redirectUrl = redirectUrl ?? "/";

            return Challenge(new AuthenticationProperties() { RedirectUri = redirectUrl },
               Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme);
            
            return RedirectToAction("Index", "Home");
        }
    }
}
