using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly SkillsMatrixDbContext _context;
        private readonly ILogger<TechnologyRepository> _logger;

        public TechnologyRepository(SkillsMatrixDbContext context, ILogger<TechnologyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Technology> GetAllTechnologies()
        {
            try
            {
                return _context.Technologies.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Technology GetTechnologyById(int technologyId)
        {
            try
            {
                return _context.Technologies
                    .Where(p => p.Id == technologyId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Technology InsertNewTechnology(Technology newTechnology)
        {
            try
            {
                _context.Technologies.Add(newTechnology);
                _context.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Technology DeleteTechnology(Technology technologyItem)
        {
            var selectedItem = _context.Technologies.Where(i => i.Name == technologyItem.Name);

            try
            {


                _context.Technologies.Remove(technologyItem);
                _context.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Technology EditTechnology(Technology technologyItem, Technology newValue)
        {
            try
            {
                _context.Technologies.Remove(technologyItem);
                _context.Technologies.Add(newValue);
                _context.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
