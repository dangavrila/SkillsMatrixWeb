using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfYears { get; set; }
        public int Level { get; set; }
        public int LastYearUsed { get; set; }
        public string Remarks { get; set; }
        public int EmployeeId { get; set; }

        public ICollection<TechnologysInSkill> TechnologyInSkills { get; set; }
    }
}
