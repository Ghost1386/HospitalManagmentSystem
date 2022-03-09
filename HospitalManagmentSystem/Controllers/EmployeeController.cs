using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;

namespace HospitalManagmentSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /*public IActionResult Create()
        {
            return View(new EmployeeViewModel());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
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
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (Employee employee in _employeeService.GetAll())
            {
                employeeViewModels.Add(new EmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    SurName = employee.SurName,
                    PhoneNumber = employee.PhoneNumber,
                    Department = employee.Department
                });
            }

            return PartialView(employeeViewModels);
        }*/
    }
}
