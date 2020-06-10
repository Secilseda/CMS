using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Authorize]//login sayfasını atlatmak istiyorsak yaptığımız bir hareket olmadan sayfayı açmayacak ettribute.
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private IPasswordHasher<AppUser> _passwordHasher;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser>signInManager,
            IPasswordHasher<AppUser> passwordHasher)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._passwordHasher = passwordHasher;
        }

        [AllowAnonymous]//atlatmış olucaz.
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.UserName,
                    Email=user.Email
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)//bir kullanıcı adı bir defa girilebilir.
                    {
                        ModelState.AddModelError("", error.Description);
                    }    
                }
            }
            return View(user);
        }


        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login
            {
                ReturnUrl = returnUrl
            };
            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(login.Email);
                if (user!=null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(login.ReturnUrl ?? "/");//??=if yapısı tek satırlık if else kodu yazabiliyoruz.
                    }
                }
                ModelState.AddModelError("", "Login failed, wrong credentials..!");
            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");// redirect edip accounta atıyoruz.
        }

        public async Task<IActionResult>Edit()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEdit userEdit = new UserEdit(appUser);
            return View(userEdit);
        }
        public async Task<IActionResult>Edit(UserEdit user)
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                appUser.Email = user.Email;
                if (user.Password!=null)
                {
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser,user.Password);
                }
                IdentityResult result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    TempData["Success"] = "Your information has been edited..!";
                }
                
            }
            return View(user);
        }
    }
}