using InternsAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternsAPI.Controllers
{
    [ApiController]
    [Route("interns")]
    public class InternsController : ControllerBase
    {
        private readonly ILogger<InternsController> _logger;
        private readonly InternsDomainService _internsDomainService;


        public InternsController(ILogger<InternsController> logger)
        {
            _logger = logger;            
            _internsDomainService = new InternsDomainService();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var response = new List<InternEntity>()
            {
                new InternEntity {
                    Name = "Alessandro",
                    Age = 25,
                    Squad = "Payment",
                    Leader = "Igor",
                    Id = new Random().Next()
                }
            };
            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post(InternEntity request)
        {
            InternEntity response = null;
            try
            {
                response = _internsDomainService.CreateIntern(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
