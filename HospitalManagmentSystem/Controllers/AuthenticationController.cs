using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.Common.Enums;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        
        public AuthenticationController(IAuthService authService, IUserService userService)
        {
            _userService = userService;
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_authService.IsLogin(userLoginViewModel.Login, userLoginViewModel.Password, out int id))
                {
                    User user = _userService.Get(id);

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, ((Role)user.Role).ToString())
                    };

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity));

                    return RedirectToAction("HomePage", "Home");
                }
            }

            return View(userLoginViewModel);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(UserViewModel userViewModel)
        {
            _userService.Create(new User
            {
                Email = userViewModel.Email,
                Login = userViewModel.Login,
                Password = userViewModel.Password,
                Role = (int)userViewModel.Role
            });

            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("HomePage", "Home");
        }
    }
}
