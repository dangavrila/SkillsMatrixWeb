using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.ViewModels
{
    public class SeatViewModel
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public TechnologyStackViewModel TechnologyStack { get; set; }
    }
}
