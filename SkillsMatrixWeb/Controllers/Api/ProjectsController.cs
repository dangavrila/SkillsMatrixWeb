using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillsMatrixWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Controllers.Api
{
    [Route("/api/projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectsRepository _repository;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectsRepository repository, ILogger<ProjectsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllProjects();
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogError("Projects could not be loaded.", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/projects/{projectId}")]
        public IActionResult Get(int projectId)
        {
            try
            {
                var result = _repository.GetProjectById(projectId);
                return Ok(result);
            }catch(Exception ex)
            {
                _logger.LogError($"Project id {projectId} could not be loaded.", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
