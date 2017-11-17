using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly SkillsMatrixDbContext _context;
        private readonly ILogger<ProjectsRepository> _logger;

        public ProjectsRepository(SkillsMatrixDbContext context, ILogger<ProjectsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            try
            {
                return _context.Projects.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public IEnumerable<Seat> GetAllSeats(int projectId)
        {
            try
            {
                return _context.Seats.Where(s => s.ProjectId == projectId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Project GetProjectById(int projectId)
        {
            try
            {
                return _context.Projects
                    .Include(p => p.Seats)
                    .Where(p => p.Id == projectId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public IEnumerable<Technology> GetTechnologiesBySeat(int seatId)
        {
            try
            {
                var result = from techStacks in _context.TechnologyStacks
                             join techsInStacks in _context.TechnologiesInTechnologiesStacks on techStacks.Id equals techsInStacks.TechnologyStackId
                             join techs in _context.Technologies on techsInStacks.TechnologyId equals techs.Id
                             where techStacks.SeatId == seatId
                             select techs;

                return result
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }

        }
    }
}
