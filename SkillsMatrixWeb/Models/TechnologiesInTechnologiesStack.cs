using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class TechnologiesInTechnologiesStack
    {
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
        public int TechnologyStackId { get; set; }
        public TechnologyStack TechnologyStack { get; set; }
    }
}
