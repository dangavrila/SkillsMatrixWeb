using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.ViewModels
{
    public class SearchResultItemViewModel
    {
        public string Text { get; set; }
        public IEnumerable<SearchResultItemViewModel> Items { get; set; }
    }
}
