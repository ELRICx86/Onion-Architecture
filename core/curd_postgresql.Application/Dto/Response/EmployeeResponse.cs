using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curd_postgresql.Application.Dto.Response
{
    public class EmployeeResponse
    {
        public int? statusCode { get; set; }
        public int? id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public int? Salary { get; set; }
    }

    public class EmployeesResponse
    {
        public int StatusCode { get; set; }
        public List<EmployeeResponse> Employees { get; set; } = new List<EmployeeResponse>();
    }



}
