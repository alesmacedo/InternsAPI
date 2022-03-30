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

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
           InternEntity response;
           try
            {
                response = _internsDomainService.GetIntern(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post(InternEntity request)
        {
            InternEntity response;
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

        [HttpPut("{id}")]
        public ActionResult Put(InternEntity request)
        {
            try
            {
                 _internsDomainService.UpdateIntern(request);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                 _internsDomainService.DeleteIntern(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex. Message);
            }
           
            return Ok();
        }
    }
}
