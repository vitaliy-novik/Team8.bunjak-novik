using Entities;
using Microsoft.AspNet.Identity;
using Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wunderlist.InterfaceRepositories;
using Wunderlist.Repositories;
using Wunderlist.WebUI.Models.AccountView;

namespace Wunderlist.WebUI.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> userManager;

        public AccountController()
        {
            IUnitOfWork uow = new UnitOfWork("DefaultConnection");
            userManager = new UserManager<User>(new AccountStore(uow));
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

                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("UserName", "Error while creating the user!");
            }
            return View(model);
        }
    }
}