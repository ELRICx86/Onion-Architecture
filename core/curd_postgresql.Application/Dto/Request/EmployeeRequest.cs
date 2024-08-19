using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curd_postgresql.Application.Dto.Request
{
    public class EmployeeRequest
    {
        public required string Name { get; set; }
        public required string Department { get; set; }
        public required int Salary { get; set; }

    }
}
