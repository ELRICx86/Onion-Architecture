using AutoMapper;
using crud_postgresql.Domain.Models;
using curd_postgresql.Application.Dto.Request;

namespace crud_postgresql.Mappers
{
    public class RequestMapper : Profile
    {
        public RequestMapper() {
            CreateMap<EmployeeRequest, Employee>();
        }

    }
}
