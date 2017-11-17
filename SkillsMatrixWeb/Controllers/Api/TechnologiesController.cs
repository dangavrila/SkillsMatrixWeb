using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillsMatrixWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Controllers.Api
{
    [Route("api/technologies")]
    public class TechnologiesController : Controller
    {
        private readonly ITechnologyRepository _repository;
        private readonly ILogger<TechnologiesController> _logger;

        public TechnologiesController(ITechnologyRepository repository, ILogger<TechnologiesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllTechnologies();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError("Technologies could not be loaded.", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
