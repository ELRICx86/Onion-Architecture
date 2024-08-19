using crud_postgresql.Domain.Interfaces.Employees;
using crud_postgresql.Repository.Employees;
using crud_postgresql.Service.EmployeeService;
using curd_postgresql.Application.Interfaces;

namespace crud_postgresql.Dependency
{
    public static class RepositoryDependency
    {
        public static IServiceCollection AddRepoDependency(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeCRUD, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    } 
}
