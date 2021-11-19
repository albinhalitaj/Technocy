using System;

namespace Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool Status { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        
        public virtual Role Role { get; set; }
        
    }
}