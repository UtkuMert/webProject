using MarketApp.webUI.Identity;
using MarketApp.webUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<UserIdentity> _userManager;
        private SignInManager<UserIdentity> _signInManager;

        public AccountController(UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }
        [HttpPost]
        
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new UserIdentity
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {

                return RedirectToAction("Login", "Account"); 
            }

            ModelState.AddModelError("", "Hata olustu");
            return View(model);
        }

        public IActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl=null)
        {
            returnUrl = returnUrl ?? "~/"; //return yapicak yer varsa oraya gider yoksa home gider
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user==null)
            {
                ModelState.AddModelError("", "Username veya Password yanlis");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false,false); //cookinin tarayıcı kapandıgında kalıcılıgı ile ilgili
            if(result.Succeeded)
            {
                return Redirect(returnUrl); //gitmek istedigi yere gider yetkisi yoksa anasayfaya doner
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public IActionResult Accessdenied() //Giris izni olmayan yere girmeye calisirsa buraya yonlendirilir
        {
            return View();
        }

    }
}
