using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public interface ITechnologyRepository
    {
        List<Technology> GetAllTechnologies();

        Technology GetTechnologyById(int technologyId);

        Technology InsertNewTechnology(Technology newTechnology);

        Technology DeleteTechnology(Technology technologyItem);

        Technology EditTechnology(Technology technologyItem, Technology newValue);
    }
}
