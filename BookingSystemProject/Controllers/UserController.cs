using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Personalization()
        {
           return View();
        }
    }
}
