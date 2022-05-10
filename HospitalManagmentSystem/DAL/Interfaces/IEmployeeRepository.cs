using System.Collections.Generic;
using HospitalManagmentSystem.Common.Models;

namespace HospitalManagmentSystem.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
    }
}
