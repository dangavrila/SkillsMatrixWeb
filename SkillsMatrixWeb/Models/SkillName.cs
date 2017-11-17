using System;
using System.Collections.Generic;

namespace SkillsMatrixWeb.Models
{
    public class SkillName
    {
        public SkillName()
        {
        }

        public int Id { get; set; }

        public int SkillCategoryId { get; set; }

        public string Name { get; set; }

        public int NumberOfYears { get; set; }

        public int Level { get; set; }

        public DateTime LastYearUsed { get; set; }

        public string Remarks { get; set; }

        public virtual ICollection<SkillCategory> SkillCategories { get; set; }
    }
}
