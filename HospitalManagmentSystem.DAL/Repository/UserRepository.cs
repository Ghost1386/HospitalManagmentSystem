using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.DAL.Interfaces;

namespace HospitalManagmentSystem.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionSettings _connectionSettings;

        public UserRepository(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query = "SELECT * FROM AppUsers";

                var command = new SqlCommand(query, connection);

                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Email = reader["Email"].ToString(),
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = Convert.ToInt32(reader["Role"])
                            });
                        }
                    }
                }

                return users;
            }
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }
    }
}
