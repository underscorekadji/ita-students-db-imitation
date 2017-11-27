using Students.Api.Model;

namespace Students.Api.Services.Interfaces
{
    public interface IFakeDataService
    {
        Employee GetFakeModel();

        void CreateEmployee();

        void UpdateEmployeeSkype(Employee employee);

        void UpdateEmployeeName(Employee employee);

        void UpdateEmployeeRank(Employee employee);

        void RemoveEmployee(Employee employee);
    }
}
