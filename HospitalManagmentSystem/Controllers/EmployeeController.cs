using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return View(new EmployeeViewModel());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Create(new Employee()
                {
                    Name = employeeViewModel.Name,
                    SurName = employeeViewModel.SurName,
                    PhoneNumber = employeeViewModel.PhoneNumber,
                    Department = employeeViewModel.Department
                });

                return RedirectToAction(nameof(Index));
            }
            
            return View(employeeViewModel);
        }
        
        public IActionResult Index()
        {
            List<EmployeeViewModel> employeeViewModel = new List<EmployeeViewModel>();
            
            if (ModelState.IsValid)
            {
                foreach (Employee employee in _employeeService.GetEmployees())
                {
                    employeeViewModel.Add(new EmployeeViewModel
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        SurName = employee.SurName,
                        PhoneNumber = employee.PhoneNumber,
                        Department = employee.Department
                    });
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
