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

        public IEnumerable<Record> GetPatientRecord(int id)
        {
            List<Record> records = new List<Record>();

            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "SELECT * FROM Records WHERE UserId = @Id";
                
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
                            records.Add(new Record() 
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Department = Convert.ToInt32(reader["Department"]),
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                DateAndTime = reader["DateAndTime"].ToString(),
                                RecordStatus = Convert.ToInt32(reader["RecordStatus"]),
                            });
                        }
                    }
                }
                
                return records;
            }
        }

        public IEnumerable<Record> GetEmployeeRecord(int id)
        {
            List<Record> records = new List<Record>();

            using (var connection = new SqlConnection(_connectionSettings.ConnectionStr))
            {
                var query =
                    "SELECT * FROM Records WHERE EmployeeId = @Id";
                
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
                            records.Add(new Record() 
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Department = Convert.ToInt32(reader["Department"]),
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                DateAndTime = reader["DateAndTime"].ToString(),
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
                                Department = Convert.ToInt32(reader["Department"]),
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                DateAndTime = reader["DateAndTime"].ToString(),
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
                    "INSERT INTO Records (UserId, Department, EmployeeId, DateAndTime, RecordStatus) VALUES (@UserId, @Department, @EmployeeId, @DateAndTime, @RecordStatus)";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("UserId", SqlDbType.Int)
                {
                    Value = record.UserId
                });

                command.Parameters.AddWithValue("Department", SqlDbType.Int);

                command.Parameters.Add(new SqlParameter("EmployeeId", SqlDbType.Int)
                {
                    Value = record.EmployeeId
                });

                command.Parameters.Add(new SqlParameter("DateAndTime", SqlDbType.NVarChar)
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
                    "UPDATE Records SET UserId=@UserId, Department=@Department, EmployeeId=@EmployeeId, " +
                    "DateAndTime=@DateAndTime, RecordStatus= @RecordStatus WHERE Id=@Id";

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

                command.Parameters.Add(new SqlParameter("DateAndTime", SqlDbType.NVarChar)
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
