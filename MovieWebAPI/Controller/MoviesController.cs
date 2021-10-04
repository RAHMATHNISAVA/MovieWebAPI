using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieWebApplication.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieService _service;

        public MoviesController(ILogger<MoviesController> logger, IMovieService service)
        {
            _logger = logger;
            _service = service;

        }
        [HttpGet]
        [Route("stats")]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Started:MoviesController:Get");
                var stats = _service.Get();
                _logger.LogInformation("Finished:MoviesController:Get"+ stats);
                return Ok(stats);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error:MoviesController:Get" + ex.ToString());
                throw ex;

            }

        }
    }
}
