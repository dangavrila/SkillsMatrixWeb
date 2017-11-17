using System;
using System.Collections.Generic;

namespace SkillsMatrixWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<EmployeeJobHistory> EmployeeJobHistories { get; set; }

    }
}
