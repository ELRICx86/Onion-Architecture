using AutoMapper;
using crud_postgresql.Domain.Interfaces.Employees;
using crud_postgresql.Domain.Models;
using curd_postgresql.Application.Dto.Request;
using curd_postgresql.Application.Dto.Response;
using curd_postgresql.Application.Interfaces;

namespace crud_postgresql.Service.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeCRUD _employeeCRUD;
        public EmployeeService(IEmployeeCRUD employeeCRUD, IMapper mapper )
        {
            _employeeCRUD = employeeCRUD;
            _mapper = mapper;
        }

        public async Task<EmployeeResponse> CreateEmployee(EmployeeRequest employee)
        {
            Employee emp = _mapper.Map<Employee>(employee);
            try
            {
                
                emp = await _employeeCRUD.AddAsync(emp);
            }
            catch(Exception ex)
            {
                throw ;
            }

            var temp =  _mapper.Map<EmployeeResponse>(employee);
            if (emp == null) temp.statusCode = 500;
            else temp.statusCode = 200;
            return temp;
            
            
        }

        public async Task<EmployeeResponse> DeleteEmployee(int id)
        {
            
            var res = await _employeeCRUD.DeleteAsync(id);
            if(res == true)
            {
                return new EmployeeResponse()
                {
                    statusCode = 200,
                };
            }
            else
            {
                return new EmployeeResponse()
                {
                    statusCode = 500,
                };
            }
             
        }

        public async Task<EmployeesResponse> GetAllEmployees()
        {
            var employees = await _employeeCRUD.GetAllAsync();

            var employeeResponses = employees.Select(e => new EmployeeResponse
            {
                id = e.Id,
                Name = e.Name,
                Department = e.Department,
                Salary = e.Salary,
                //statusCode = 200 // Assuming all retrieved employees are valid
            }).ToList();

            var response = new EmployeesResponse
            {
                StatusCode = employeeResponses.Any() ? 200 : 404, // Status code 404 if no employees found
                Employees = employeeResponses
            };

            return response;
        }



        public async Task<EmployeeResponse> GetEmployeeById(int id)
        {
            var res = await _employeeCRUD.GetAsync(id);
            var temp = _mapper.Map<EmployeeResponse>(res);
            if (res != null) temp.statusCode = 200;
            else temp.statusCode = 500;
            return temp;
        }

        public async Task<EmployeeResponse> UpdateEmployee(int id, EmployeeRequest employee)
        {
            Employee emp = _mapper.Map<Employee>(employee);
            var res = await _employeeCRUD.UpdateAsync(id, emp);
            if (res == true)
            {
                return new EmployeeResponse()
                {
                    statusCode = 200,
                };
            }
            else
            {
                return new EmployeeResponse()
                {
                    statusCode = 500,
                };
            }
        }
    }
}
