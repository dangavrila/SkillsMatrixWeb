using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillsMatrixWeb.Models;
using System;

namespace SkillsMatrixWeb.Controllers.Api
{
    [Route("/api/seats")]
    public class SeatsController : Controller
    {
        private readonly IProjectsRepository _repository;
        private readonly ILogger<SeatsController> _logger;

        public SeatsController(IProjectsRepository repository, ILogger<SeatsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get(int seatId)
        {
            try
            {
                var tech = _repository.GetTechnologiesBySeat(seatId);
                return Ok(tech);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Project id {seatId} could not be loaded.", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
