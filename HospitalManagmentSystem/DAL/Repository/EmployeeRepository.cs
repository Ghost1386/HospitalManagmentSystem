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

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query = "SELECT * FROM Employees";

                var command = new SqlCommand(query, connection);

                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                SurName = reader["SurName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Department = reader["Department"].ToString(),
                            });
                        }
                    }
                }

                return employees;
            }
        }

        public Employee Get(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "SELECT * FROM Employees WHERE Id = @Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = id
                });

                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new Employee
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                SurName = reader["SurName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Department = reader["Department"].ToString(),
                            };
                        }
                    }
                }

                return new Employee();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "DELETE FROM Employees WHERE Id=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = id
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Create(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "INSERT INTO Employees (Name, SurName, PhoneNumber, Department) VALUES (@Name, @SurName, @PhoneNumber, @Department)";

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Name", employee.Name);

                command.Parameters.AddWithValue("SurName", employee.SurName);

                command.Parameters.AddWithValue("PhoneNumber", employee.PhoneNumber);

                command.Parameters.AddWithValue("Department", employee.Department);

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
