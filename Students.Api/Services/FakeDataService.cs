using System;

using Students.Api.DataAccess.Interfaces;
using Students.Api.Model;
using Students.Api.Services.Interfaces;

namespace Students.Api.Services
{
    public class FakeDataService : IFakeDataService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly string[] _employeeRanks;
        private readonly string[] _employeeRoom;

        public FakeDataService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
            this._employeeRanks = new string[]
            {
                "Department Manager", "Group Manager", "Software Engineer", "Quality Assurance Engineer",
                "None", "Chief Executive Officer", "Senior Software Engineer", "HR Manager",
                "Business Development Manager", "Technical Support Engineer", "Telemarketer",
                "Senior Quality Assurance Engineer", "Lead Software Engineer", "Support Staff",
                "Designer", "Accountant", "PR Manager", "Marketing Manager", "Lead Quality Assurance Engineer"
            };
            this._employeeRoom = new string[]
            {
                "Minks | 101", "Minks | 102", "Minks | 103", "Minks | 104", "Minks | 105", "Minks | 106", "Minks | 107", "Minks | 108",
                "Minks | 201", "Minks | 202", "Minks | 203", "Minks | 204", "Minks | 205", "Minks | 206", "Minks | 207", "Minks | 208"
            };
        }

        /// <summary>
        /// Creates the employee.
        /// </summary>
        public void CreateEmployee()
        {
            System.Diagnostics.Debug.WriteLine("Create Employee");
            this._employeeRepository.AddEmployee(GetFakeModel());
        }

        /// <summary>
        /// Removes the employee.
        /// </summary>
        public void RemoveEmployee(Employee employee)
        {
            System.Diagnostics.Debug.WriteLine($"Remove Employee: {employee.Id}");
            this._employeeRepository.RemoveEmployee(employee.Id);
        }

        public Employee GetFakeModel()
        {
            return new Employee()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                DomenName = Faker.Internet.DomainName(),
                Email = Faker.Internet.Email(),
                Birthday = RandomDate(1970, 1, 1),
                DeptId = RandomDept(),
                Phone = Faker.Phone.Number(),
                Rank = RandomRank(),
                EmploymentDate = RandomDate(2010, 1, 1),
                Room = RandomRoom(),
                Skype = Faker.Internet.UserName(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            };
        }

        /// <summary>
        /// Updates the name of the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void UpdateEmployeeName(Employee employee)
        {
            System.Diagnostics.Debug.WriteLine($"Update Employee Name: {employee.Id}");
            employee.FirstName = Faker.Name.First();
            employee.LastName = Faker.Name.Last();

            this._employeeRepository.UpdateEmployee(employee.Id, employee);
        }

        /// <summary>
        /// Updates the employee rank.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void UpdateEmployeeRank(Employee employee)
        {
            System.Diagnostics.Debug.WriteLine($"Update Employee Rank: {employee.Id}");
            employee.Rank = this.RandomRank();

            this._employeeRepository.UpdateEmployee(employee.Id, employee);
        }

        /// <summary>
        /// Updates the employee skype.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void UpdateEmployeeSkype(Employee employee)
        {
            System.Diagnostics.Debug.WriteLine($"Update Employee Skype: {employee.Id}");
            employee.Skype = Faker.Internet.UserName();

            this._employeeRepository.UpdateEmployee(employee.Id, employee);
        }

        /// <summary>
        /// Randoms the date.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        private string RandomDate(int year, int month, int day)
        {
            var random = new Random();

            DateTime start = new DateTime(year, month, day);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range)).ToString("o");
        }

        /// <summary>
        /// Randoms the dept.
        /// </summary>
        /// <returns></returns>
        private int RandomDept()
        {
            var random = new Random();
            return random.Next(10) + 1;
        }

        /// <summary>
        /// Randoms the rank.
        /// </summary>
        /// <returns></returns>
        private string RandomRank()
        {
            var random = new Random();
            return this._employeeRanks[random.Next(this._employeeRanks.Length)];
        }

        /// <summary>
        /// Randoms the room.
        /// </summary>
        /// <returns></returns>
        private string RandomRoom()
        {
            var random = new Random();
            return this._employeeRoom[random.Next(this._employeeRoom.Length)];
        }
    }
}
