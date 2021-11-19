using System.Collections.Generic;

namespace Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }
        
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Employee> Employees { get; set; }
    }
}