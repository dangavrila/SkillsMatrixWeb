using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.ViewModels
{
    public class TechnologyStackViewModel
    {
        private readonly List<TechnologyViewModel> _technologies;
        private readonly string _name;

        public string Name { get { return _name; } }
        public string Details { get; set; }

        public TechnologyStackViewModel(string name)
        {
            _name = name;
            _technologies = new List<TechnologyViewModel>();
        }

        public List<TechnologyViewModel> Technologies { get { return _technologies; } }
    }
}
