using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        public ICollection<TechnologiesInTechnologiesStack> TechnologiesInTechnologiesStacks { get; set; }
        public ICollection<TechnologysInSkill> TechnologyInSkills { get; set; }
    }
}
