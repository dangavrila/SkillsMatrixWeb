using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public interface IProjectsRepository
    {
        IEnumerable<Project> GetAllProjects();

        Project GetProjectById(int projectId);

        IEnumerable<Technology> GetTechnologiesBySeat(int seatId);

        IEnumerable<Seat> GetAllSeats(int projectId);
    }
}
