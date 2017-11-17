using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.ViewModels
{
    public class TechnologyViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Version { get; set; }
        public List<SelectListItem> TechnologyList { get; set; }

    }

}
