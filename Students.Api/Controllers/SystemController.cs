using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Api.DataAccess.Interfaces;
using Students.Api.Model;
using Students.Api.Services.Interfaces;

namespace Students.Api.Controllers
{
    [Route("api/[controller]")]
    public class SystemController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFakeDataService _fakeDataService;

        public SystemController(
            IEmployeeRepository employeeRepository,
            IFakeDataService fakeDataService)
        {
            this._employeeRepository = employeeRepository;
            this._fakeDataService = fakeDataService;
        }

        /// <summary>
        /// Call an initialization - api/system/init
        /// </summary>
        [HttpGet("{setting}")]
        public async Task<int> Get(string setting)
        {
            if (setting == "init")
            {
                await this._employeeRepository.RemoveAllEmployees();

                for (int i = 0; i < 10; i++)
                {
                    await this._employeeRepository.AddEmployee(this._fakeDataService.GetFakeModel());
                }

                return StatusCodes.Status200OK;
            }

            return StatusCodes.Status400BadRequest;
        }
    }
}
