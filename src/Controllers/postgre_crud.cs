using crud_postgresql.Domain.Interfaces.Employees;
using crud_postgresql.Domain.Models;
using curd_postgresql.Application.Dto.Request;
using curd_postgresql.Application.Dto.Response;
using curd_postgresql.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_postgresql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postgre_crud : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public postgre_crud(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("/get/{id}")]
        public async Task<IActionResult> GetEmployeebyId(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));
        }

        [HttpGet("/getall")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok();
        }

        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _employeeService.DeleteEmployee(id));
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateNewEmployee([FromBody]EmployeeRequest employee)
        {
            EmployeeResponse temp = await _employeeService.CreateEmployee(employee);
            return Ok(temp);
        }

        [HttpPut("/update/{id}")]
        public async Task<IActionResult> CreateNewEmployee(int id)
        {
            return Ok(new { message = $"employee with id:{id} updated" });
        }
    }
}
