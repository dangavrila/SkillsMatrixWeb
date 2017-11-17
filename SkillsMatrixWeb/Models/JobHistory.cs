using System;
using System.Collections.Generic;

namespace SkillsMatrixWeb.Models
{
    public class JobHistory
    {
        public int Id { get; set; }

        public DateTime Startdate { get; set; }

        public DateTime? EndDate { get; set; }

        public float Capacity { get; set; }

        public int SeatId { get; set; }

        public virtual ICollection<EmployeeJobHistory> EmployeeJobHistories { get; set; }

    }
}