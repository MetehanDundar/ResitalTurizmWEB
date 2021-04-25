using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.UI.Identity;
using ResitalTurizmWEB.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Controllers
{
    /*[AutoValidateAntiforgeryToken]*/ //tek tek metot bazında yapmaktansa bu sekilde genel olarak da kontrol saglanabilir.
    public class AccountController : Controller
    {
        private UserManager<User> _userManager; //kullanıcı olusturma, login, parola sıfırlama gibi islemler için
        private SignInManager<User> _signInManager; //cookie olaylarını yönetecek
        private ICartService _cartService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartService = cartService;
        }

        public IActionResult Login(string ReturnUrl=null) //varsayılan null (Post'ta null kontrolü yapabilmem için)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Csrf ataklarının önüne geçmek için
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var user = await _userManager.FindByNameAsync(model.UserName);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user==null)
            {
                ModelState.AddModelError("","Bu Email ile daha önce hesap oluşturulmamış.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false); //3. parametre tarayıcı kapandıgında cookie silinmesiyle ilgili.(true verirsek belirlenen sürede silinir). 4. parametre ise lockout işlemi açık mı olsun kapalı mı olsun.

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl??"~/"); //null ise anasayfaya git.
            }

            ModelState.AddModelError("", "Girilen email veya parola yanlış.");
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //cart objesini olustur
                _cartService.InitializeCart(user.Id);
                //token üret
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
