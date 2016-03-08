using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Stores;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wunderlist.InterfaceRepositories;
using Wunderlist.Repositories;
using Wunderlist.WebUI.Models.AccountView;

namespace Wunderlist.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AccountController()
        {
            IUnitOfWork uow = new UnitOfWork("DefaultConnection");
            _userManager = new UserManager<User>(new AccountStore(uow));
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult>  Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.Name,
                    Email = model.Email,
                    Password = model.Password
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("UserName", "Error while creating the user!");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindAsync(model.Email, model.Password);

                if (user != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                    ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationProperties props = new AuthenticationProperties();
                    props.IsPersistent = true;
                    authenticationManager.SignIn(props, identity);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }
        
        public ActionResult LogOut()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                IdentityResult result = await _userManager.ChangePasswordAsync(user.Id, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Error while changing the password.");
                }
            }
            return View(model);
        }
    }
}