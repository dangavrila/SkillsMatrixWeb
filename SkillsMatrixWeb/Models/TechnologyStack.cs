using System.Collections.Generic;

namespace SkillsMatrixWeb.Models
{
    public class TechnologyStack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int SeatId { get; set; }

        public ICollection<TechnologiesInTechnologiesStack> TechnologiesInTechnologiesStacks { get; set; }
    }
}
