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
                var query = "SELECT * FROM Users";

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
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "SELECT * FROM Users WHERE Id = @Id";

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
                            return new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Email = reader["Email"].ToString(),
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = Convert.ToInt32(reader["Role"])
                            };
                        }
                    }
                }

                return new User();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "DELETE FROM AppUsers WHERE Id=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = id
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Create(User user)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "INSERT INTO AppUsers (Email, Login, Password, Role) VALUES (@Email, @Login, @Password, @Role)";

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Email", user.Email);

                command.Parameters.AddWithValue("Login", user.Login);

                command.Parameters.Add(new SqlParameter("Password", SqlDbType.Text)
                {
                    Value = user.Password
                });

                command.Parameters.Add(new SqlParameter("Role", SqlDbType.Int)
                {
                    Value = user.Role
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
