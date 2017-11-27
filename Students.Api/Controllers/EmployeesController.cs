using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Students.Api.DataAccess.Interfaces;
using Students.Api.Model;
using Students.Api.Services.Interfaces;

namespace Students.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFakeDataService _fakeDataService;

        public EmployeesController(
            IEmployeeRepository employeeRepository,
            IFakeDataService fakeDataService)
        {
            this._employeeRepository = employeeRepository;
            this._fakeDataService = fakeDataService;
        }

        [HttpGet]
        public Task<IEnumerable<Employee>> Get()
        {
            return GetNoteInternal();
        }

        private async Task<IEnumerable<Employee>> GetNoteInternal()
        {
            for (int i = 0; i < 3; i++)
            {
                var random = new Random();
                var tmp = (await _employeeRepository.GetEmployees()).ToList();
                var currentEmployee = tmp[random.Next(tmp.Count)];

                switch (random.Next(5))
                {
                    case 0:
                        _fakeDataService.CreateEmployee();
                        break;
                    case 1:
                        _fakeDataService.UpdateEmployeeName(currentEmployee);
                        break;
                    case 2:
                        _fakeDataService.UpdateEmployeeRank(currentEmployee);
                        break;
                    case 3:
                        _fakeDataService.UpdateEmployeeSkype(currentEmployee);
                        break;
                    case 4:
                        _fakeDataService.RemoveEmployee(currentEmployee);
                        break;
                    default:
                        break;
                }
            }

            return await _employeeRepository.GetEmployees();
        }
    }
}
