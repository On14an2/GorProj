using GorProj.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GorProj.Controllers
{
    public class HomeController : Controller
    {
        HoldingContext dbContext;

        public HomeController(HoldingContext context)
        {
            dbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(Index);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Employees");
        }
        [HttpPost]
        public async Task<IActionResult> Authorization(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Логин и/или пароль не установлены.");
            }

            var worker = await dbContext.Accounts.FirstOrDefaultAsync(w => w.LoginAccount == login && w.PasswordAccount == password);
            if (worker == null)
            {
                return Unauthorized();
            }

            var job = await dbContext.Roles.FirstOrDefaultAsync(r => r.IdRole == worker.IdRole);
            if (job == null)
            {
                return NotFound("Роль не найдена у данного пользователя.");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, worker.LoginAccount),
                new Claim(ClaimTypes.Role, job.NameRole)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);

            return RedirectToAction("Index", "Employees");
        }
    }
}
