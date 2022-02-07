using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
