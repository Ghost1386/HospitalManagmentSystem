using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            _employeeService.Create(new Employee()
            {
                Name = employeeViewModel.Name,
                SurName = employeeViewModel.SurName,
                PhoneNumber = employeeViewModel.PhoneNumber,
                Department = (int)employeeViewModel.Department
            });

            return RedirectToAction("HomePage", "Home");
        }
    }
}
