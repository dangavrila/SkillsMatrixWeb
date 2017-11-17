using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class EmployeeJobHistory
    {
        public int EmployeeId { get; set; }

        public int JobHistoryId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual JobHistory JobHistory { get; set; }
    }
}
