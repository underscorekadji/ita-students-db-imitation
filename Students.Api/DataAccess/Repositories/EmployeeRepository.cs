using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

using Students.Api.DataAccess.Interfaces;
using Students.Api.Model;

namespace Students.Api.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context = null;

        public EmployeeRepository(IOptions<Settings> settings)
        {
            _context = new EmployeeContext(settings);
        }

        #region Implementation of IEmployeeRepository

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="data">The employee data.</param>
        public async Task AddEmployee(Employee data)
        {
            try
            {
                await _context.Employees.InsertOneAsync(data);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        public async Task<Employee> GetEmployee(string id)
        {
            var filter = Builders<Employee>.Filter.Eq("Id", id);

            try
            {
                return await _context.Employees.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                return await _context.Employees.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        /// <summary>
        /// Removes all employees.
        /// </summary>
        public async Task<bool> RemoveAllEmployees()
        {
            try
            {
                DeleteResult actionResult = await _context.Employees.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        /// <summary>
        /// Removes the employee.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        public async Task<bool> RemoveEmployee(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Employees.DeleteOneAsync(Builders<Employee>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        /// <param name="data">The model.</param>
        public async Task<bool> UpdateEmployee(string id, Employee data)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Employees.ReplaceOneAsync(n => n.Id.Equals(id), data, new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        #endregion
    }
}
