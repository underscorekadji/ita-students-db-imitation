using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Students.Api.Model
{
    public class Employee
    {
        [BsonId]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string Birthday { get; set; }

        public long DeptId { get; set; }

        public string DomenName { get; set; }

        public string Email { get; set; }

        public string EmploymentDate { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        public long ProfileId { get; set; }

        public string Rank { get; set; }

        public string Room { get; set; }

        public string Skype { get; set; }

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
