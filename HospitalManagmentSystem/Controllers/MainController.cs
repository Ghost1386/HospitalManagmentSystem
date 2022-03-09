using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.Controllers
{
    public class MainController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
    }
}