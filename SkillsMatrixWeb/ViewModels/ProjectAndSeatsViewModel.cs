using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.ViewModels
{
    public class ProjectAndSeatsViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<SelectListItem> ProjectsList { get; set; }

        public int SeatId { get; set; }
        public string PositionName { get; set; }
        public TechnologyStackViewModel TechnologyStack { get; set; }
    }
}
