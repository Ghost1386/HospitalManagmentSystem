using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.DAL.Interfaces;

namespace HospitalManagmentSystem.DAL.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly ConnectionSettings _connectionSettings;

        public RecordRepository(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        public IEnumerable<Record> GetRecord()
        {
            List<Record> records = new List<Record>();

            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query = "SELECT * FROM Records";

                var command = new SqlCommand(query, connection);

                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            records.Add(new Record
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Department = reader["Department"].ToString(),
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                DateAndTime = (DateTime)(reader["DateAndTime"]),
                                RecordStatus = Convert.ToInt32(reader["RecordStatus"]),
                            });
                        }
                    }
                }

                return records;
            }
        }

        public Record Get(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "SELECT * FROM Records WHERE Id = @Id";

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
                            return new Record
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Department = reader["Department"].ToString(),
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                DateAndTime = (DateTime)(reader["DateAndTime"]),
                                RecordStatus = Convert.ToInt32(reader["RecordStatus"]),
                            };
                        }
                    }
                }

                return new Record();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "DELETE FROM Records WHERE Id=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = id
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Create(Record record)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "INSERT INTO Records (Email, Login, Password, Role) VALUES (@Email, @Login, @Password, @Role)";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("UserId", SqlDbType.Int)
                {
                    Value = record.UserId
                });

                command.Parameters.AddWithValue("Department", record.Department);

                command.Parameters.Add(new SqlParameter("EmployeeId", SqlDbType.Int)
                {
                    Value = record.EmployeeId
                });

                command.Parameters.Add(new SqlParameter("DateAndTime", SqlDbType.DateTime)
                {
                    Value = record.DateAndTime
                });

                command.Parameters.Add(new SqlParameter("RecordStatus", SqlDbType.Int)
                {
                    Value = record.RecordStatus
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Record record)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "UPDATE Records SET Email=@Email, Login=@Login, Role=@Role WHERE Id=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = record.Id
                });

                command.Parameters.Add(new SqlParameter("UserId", SqlDbType.Int)
                {
                    Value = record.UserId
                });

                command.Parameters.AddWithValue("Department", record.Department);

                command.Parameters.Add(new SqlParameter("EmployeeId", SqlDbType.Int)
                {
                    Value = record.EmployeeId
                });

                command.Parameters.Add(new SqlParameter("DateAndTime", SqlDbType.DateTime)
                {
                    Value = record.DateAndTime
                });

                command.Parameters.Add(new SqlParameter("RecordStatus", SqlDbType.Int)
                {
                    Value = record.RecordStatus
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
