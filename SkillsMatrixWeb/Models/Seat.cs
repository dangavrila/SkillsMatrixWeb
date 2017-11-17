using SkillsMatrixWeb.Models;
using System;
using System.Collections.Generic;

public class Seat
{
    public int Id { get; set; }
    public string PositionName { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }

    public ICollection<TechnologyStack> TechnologyStacks { get; set; }
    public ICollection<JobHistory> JobHistories { get; set; }
}
