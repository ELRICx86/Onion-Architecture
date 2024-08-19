using crud_postgresql.Domain.Interfaces.Employees;
using crud_postgresql.Domain.Models;
using curd_postgresql.Application.AppSettings;
using Npgsql;

namespace crud_postgresql.Repository.Employees
{
    public class EmployeeRepository : IEmployeeCRUD
    {
        private readonly DBConn _dBConn;

        public EmployeeRepository(DBConn dBConn)
        {
            _dBConn = dBConn;
        }

        #region Add
        public async Task<Employee> AddAsync(Employee entity)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_dBConn.connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new NpgsqlCommand("SELECT public.create_employee(@p_name, @p_department, @p_salary)", connection))
                    {
                        command.Parameters.AddWithValue("p_name", entity.Name);
                        command.Parameters.AddWithValue("p_department", entity.Department);
                        command.Parameters.AddWithValue("p_salary", entity.Salary);

                        await command.ExecuteNonQueryAsync();
                    }

                    await connection.CloseAsync();
                }

                return entity;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        #endregion


        #region Delete
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_dBConn.connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new NpgsqlCommand("SELECT public.delete_employee(@p_id)", connection))
                    {
                        command.Parameters.AddWithValue("p_id", id);

                        await command.ExecuteNonQueryAsync();
                    }

                    await connection.CloseAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                 // Rethrow the exception if you want to propagate it further
                return false;
            }
            
        }

        #endregion


        #region GetAll
        public Task<Employee> GetAllAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Get
        public async Task<Employee> GetAsync(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_dBConn.connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new NpgsqlCommand("SELECT * from public.get_employee_by_id(@p_id)", connection))
                    {
                        command.Parameters.AddWithValue("p_id", id);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                var employee = new Employee
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Department = reader.GetString(reader.GetOrdinal("department")),
                                    Salary = (int)reader.GetDecimal(reader.GetOrdinal("salary"))
                                };
                                return employee;
                            }
                            else
                            {
                                return null; // Employee not found
                            }
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        #endregion


        #region Update
        public Task<bool> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
