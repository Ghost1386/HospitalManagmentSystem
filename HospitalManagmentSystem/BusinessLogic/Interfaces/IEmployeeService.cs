using System.Collections.Generic;
using HospitalManagmentSystem.Common.Models;

namespace HospitalManagmentSystem.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();

        Employee Get(int id);

        void Delete(int id);

        void Create(Employee employee);
    }
}
