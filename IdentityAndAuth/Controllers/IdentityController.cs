using IdentityAndAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAndAuth.Controllers
{
    public class IdentityController : Controller
    {
        public async Task<IActionResult>SignUp()
        {
            var model = new SignUp();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp model)
        {
            return View(model);
        }

        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
