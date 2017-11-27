using System.Collections.Generic;
using System.Threading.Tasks;

using Students.Api.Model;

namespace Students.Api.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(string id);

        Task AddEmployee(Employee item);

        Task<bool> UpdateEmployee(string id, Employee model);

        Task<bool> RemoveEmployee(string id);

        Task<bool> RemoveAllEmployees();
    }
}
