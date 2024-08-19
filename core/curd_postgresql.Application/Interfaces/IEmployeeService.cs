using curd_postgresql.Application.Dto.Request;
using curd_postgresql.Application.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curd_postgresql.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> GetEmployeeById(int id);
        Task<EmployeeResponse> UpdateEmployee(int id, EmployeeRequest employee);
        Task<EmployeeResponse> DeleteEmployee(int id);
        Task<EmployeesResponse> GetAllEmployees();
        Task<EmployeeResponse> CreateEmployee(EmployeeRequest employee);
    }
}
