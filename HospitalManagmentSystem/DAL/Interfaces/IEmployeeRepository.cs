﻿using System.Collections.Generic;
using HospitalManagmentSystem.Common.Models;

namespace HospitalManagmentSystem.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        Employee Get(int id);

        void Delete(int id);

        void Create(Employee employee);
    }
}