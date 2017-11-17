using System;
using System.Collections.Generic;

namespace SkillsMatrixWeb.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HoursNeed { get; set; }
        public bool IsOpen { get; set; }
        public DateTime Deadline { get; set; }
        public string Location { get; set; }
        public int MinimumSkillLevel { get; set; }
        public string UserName { get; set; }

        public ICollection<Seat> Seats { get; set; }
        
    }
}
