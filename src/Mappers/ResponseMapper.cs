using AutoMapper;
using crud_postgresql.Domain.Models;
using curd_postgresql.Application.Dto.Request;
using curd_postgresql.Application.Dto.Response;

namespace crud_postgresql.Mappers
{
    public class ResponseMapper : Profile
    {
        public ResponseMapper()
        {
            CreateMap<Employee, EmployeeResponse>();
            
            CreateMap<EmployeeRequest, EmployeeResponse>();
        }
    }
}
