using System.Collections.Generic;
using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.DAL.Interfaces;

namespace HospitalManagmentSystem.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public Employee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }

        public void Create(Employee employee)
        {
            _employeeRepository.Create(employee);
        }
    }
}
