using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View(_userService.GetUsers());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_authService.IsRegistration(userViewModel.Login, userViewModel.Password))
                {
                    return View(userViewModel);
                }
                
                _userService.Create(new User()
                {
                    Email = userViewModel.Email,
                    Login = userViewModel.Login,
                    Password = userViewModel.Password
                });

                return RedirectToAction(nameof(Index));
            }

            return View(userViewModel);
        }
    }
}
