using books_api.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Controllers
{
    /// <summary>
    /// Endpoint used to interface with the author in the bool store's database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILoggerService _logger;

        public AuthorsController(IAuthorRepository authorRepository, ILoggerService logger)
        {
         _authorRepository = authorRepository;
            _logger = logger;
        
    }
    }
}
