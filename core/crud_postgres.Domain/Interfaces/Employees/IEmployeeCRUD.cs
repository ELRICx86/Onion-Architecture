using crud_postgresql.Domain.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("crud_postgresql.Repository")]
namespace crud_postgresql.Domain.Interfaces.Employees
{
    public interface IEmployeeCRUD : IBaseCRUD<Employee>
    {

    }
}
