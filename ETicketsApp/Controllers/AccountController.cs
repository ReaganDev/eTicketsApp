using System.Threading.Tasks;
using ETicketsApp.Data;
using ETicketsApp.Data.ViewModels;
using ETicketsApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicketsApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, AppDbContext context)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _context = context;
        }
        public IActionResult Login()
        {
            var res = new LoginVM();
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if (passwordCheck)
                {
                    var result = await _signinManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong Credentials. Please Try again";
                return View(model);
            }

            TempData["Error"] = "Wrong Credentials. Please Try again";
            return View(model);
        }

        public IActionResult Register()
        {
            var res = new RegisterVM();
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                TempData["Error"] = "Email Address already in use";
                return View(model);
            }

            var newUser = new AppUser()
            {
                Email = model.Email,
                FullName = model.FullName,
                UserName = model.Email
            };
            var newUserRes = await _userManager.CreateAsync(newUser, model.Password);
            if (newUserRes.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRole.User);
            }

            return View("RegistrationComplete");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }
    }
}
