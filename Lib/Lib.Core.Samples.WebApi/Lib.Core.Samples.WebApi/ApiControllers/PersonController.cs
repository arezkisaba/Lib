using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lib.Core.Samples.WebApi.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(
            IPersonService personService,
            ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet("")]
        public IEnumerable<Person> Get()
        {
            try
            {
                _logger.LogInformation(1, "GetAll()");
                return _personService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(1, ex, ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public Person Get(string id)
        {
            try
            {
                _logger.LogInformation(1, "Get()");
                return _personService.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(1, ex, ex.Message);
                throw;
            }
        }

        [HttpPost("")]
        public Person Post([FromBody] Person obj)
        {
            try
            {
                _logger.LogInformation(1, "Create()");
                return _personService.Create(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(1, ex, ex.Message);
                throw;
            }
        }

        [HttpPut("")]
        public Person Put([FromBody] Person obj)
        {
            try
            {
                _logger.LogInformation(1, "Update()");
                return _personService.Update(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(1, ex, ex.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            try
            {
                _logger.LogInformation(1, "Delete()");
                _personService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(1, ex, ex.Message);
                throw;
            }
        }

        [HttpDelete("")]
        public void Clear()
        {
            try
            {
                _logger.LogInformation(1, "Clear()");
                _personService.Clear();
            }
            catch (Exception ex)
            {
                _logger.LogError(1, ex, ex.Message);
                throw;
            }
        }
    }
}
