using ETicketsApp.Data;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
