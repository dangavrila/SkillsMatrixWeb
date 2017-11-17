using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class TechnologysInSkill
    {
        public int TechnologyId { get; set; }
        public int SkillId { get; set; }

        public Technology Technology { get; set; }
        public Skill Skill { get; set; }
    }
}