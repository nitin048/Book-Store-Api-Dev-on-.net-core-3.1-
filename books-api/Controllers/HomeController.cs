using books_api.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace books_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILoggerService _logger;

        public HomeController(ILoggerService logger)
        {
            _logger = logger;
        }
        /// <summary>
        ///  To get values  
        /// </summary>
        /// <returns></returns>
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            _logger.logInfo("Accessed home controller");
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// To get data 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            _logger.logDebug("this is get");
            return "value";
        }


        /// <summary>
        /// To post data
        /// </summary>
        /// <param name="value"></param>
        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _logger.logError("this is error");

        }


        /// <summary>
        /// To put values 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        /// <summary>
        /// To delete data
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.logWarn("this is a warn");
        }
    }
}
