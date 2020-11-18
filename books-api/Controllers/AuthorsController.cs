using AutoMapper;
using books_api.Contracts;
using books_api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Controllers
{
    /// <summary>
    /// Endpoint used to interface with the author in the book store's database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository, ILoggerService logger, IMapper mapper)
        {
         _authorRepository = authorRepository;
         _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all Authors 
        /// </summary>
        /// <returns>List of Authors</returns>
        /// 
        [HttpGet]
        
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                _logger.logInfo("Attempted Get All Authors");
                var authors = await _authorRepository.FindAll();
                var response = _mapper.Map<List<AuthorDTO>>(authors);
                _logger.logInfo("Successfully got all Authors");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            try
            {
                _logger.logInfo($"Attempted Get Author with id:{id}");
                var author = await _authorRepository.FindById(id);
                if(author == null)
                {
                    _logger.logWarn($"Attempted Get Author with id:{id} was not found");
                    return NotFound();
                }
                var response = _mapper.Map<List<AuthorDTO>>(author);
                _logger.logInfo($"Successfully got all Author with id :{id}");
                return Ok(response);
            }
            catch (Exception e)
            {
               return InternalError($"{e.Message} - {e.InnerException}");
              
            }

        }

        private ObjectResult InternalError(string message)
        {
            _logger.logError(message);
            return StatusCode(500, "Something went worng.Please contact to Admin.");

        }
    }
}
