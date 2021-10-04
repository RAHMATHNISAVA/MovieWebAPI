using Boxed.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieWebApplication.Model;
using MovieWebApplication.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        private readonly ILogger<MetadataController> _logger;
        private readonly IMetadataService _service;

        public MetadataController(ILogger<MetadataController> logger, IMetadataService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var metadata = _service.Get(id);
                if (!metadata.Any())
                    throw new HttpException(404, "File Not Found");
                return Ok(metadata);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Post(Metadata model)
        {
            try
            {
                _logger.LogInformation("Started:MetadataController:Post");
                var result = _service.Post(model);
                _logger.LogInformation("Finished:MetadataController:Post" + result);
                if (result)
                    return Ok();
                return BadRequest();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error:MetadataController:Post" + ex.ToString());
                throw ex;
            }

        }
    }
}
