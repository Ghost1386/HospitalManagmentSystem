using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.DAL.Interfaces;

namespace HospitalManagmentSystem.DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionSettings _connectionSettings;
        
        public EmployeeRepository(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        public void Create(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "INSERT INTO Employees (Name, SurName, PhoneNumber, Department) VALUES (@Name, @SurName, @PhoneNumber, @Department)";

                var command = new SqlCommand(query, connection);
                
                command.Parameters.Add(new SqlParameter("Name", SqlDbType.Text)
                {
                    Value = employee.Name
                });
                
                command.Parameters.Add(new SqlParameter("SurName", SqlDbType.Text)
                {
                    Value = employee.SurName
                });
                
                command.Parameters.Add(new SqlParameter("PhoneNumber", SqlDbType.Text)
                {
                    Value = employee.PhoneNumber
                });
                
                command.Parameters.Add(new SqlParameter("Department", SqlDbType.Int)
                {
                    Value = employee.Department
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
