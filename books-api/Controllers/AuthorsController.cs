using AutoMapper;
using books_api.Contracts;
using books_api.Data;
using books_api.DTO;
using Microsoft.AspNetCore.Authorization;
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
        private object authorDTO;

        public AuthorsController(IAuthorRepository authorRepository, ILoggerService logger, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _logger = logger;
            _mapper = mapper;
        }


        #region Setting up Get Method
        /// <summary>
        /// Get all Authors 
        /// </summary>
        /// <returns>List of Authors</returns>
        /// 
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAuthors()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Attempted Get All Authors");
                var authors = await _authorRepository.FindAll();
                var response = _mapper.Map<List<AuthorDTO>>(authors);
                _logger.logInfo($"{location}:Successfully got all Authors");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");
            }

        }
        #endregion Setting up Get Method

        #region Setting up Get Method by Id
        /// <summary>
        /// Get author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list of author by id </returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Attempted Get Author with id:{id}");
                var author = await _authorRepository.FindById(id);
                if (author == null)
                {
                    _logger.logWarn($"{location}:Attempted Get Author with id:{id} was not found");
                    return NotFound();
                }
                var response = _mapper.Map<List<AuthorDTO>>(author);
                _logger.logInfo($"{location}:Successfully got all Author with id :{id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");

            }

        }
        #endregion Setting up Get Method by Id

        #region Setting up Post Method 
        /// <summary>
        /// Created Author
        /// </summary>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Adiministrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody]AuthorCreateDTO authorDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Author Submission Attempted");
                if (authorDTO == null)
                {
                    _logger.logWarn($"{location}:Empty request is submitted ");
                    return BadRequest(ModelState);
                }

                if(!ModelState.IsValid)
                {
                    _logger.logWarn($"{location}:Author data was incompete");
                    return BadRequest(ModelState);

                }
                
                var author = _mapper.Map<Author>(authorDTO);

                var isSuccess = await _authorRepository.Create(author);
                if(!isSuccess)
                {
                    return InternalError($"{location}:Author creation Failed");
                }
                return Created("create", new { author });
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");

            }

        }

        #endregion Setting up Post Method 

        #region Setting up Put Method by Id
        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Adiministrator, Customer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] AuthorUpdateDTO authorDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Author Update Attempted = id:{id}");
                if (id < 1 || authorDTO == null || id != authorDTO.Id)
                {
                    _logger.logWarn($"{location}:Empty request is submitted = id :{id} ");
                    return BadRequest();
                }

                var isExists = await _authorRepository.IsExists(id);
                if (!isExists)
                {
                    _logger.logWarn($"{location}:Attempted Update Author with id:{id} was not found");
                    return NotFound();
                }

                var author = _mapper.Map<Author>(authorDTO);

                var isSuccess = await _authorRepository.Update(author);

                if (!isSuccess)
                {
                    return InternalError($"{location}:Author Updation Failed");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");

            }

        }

        #endregion Setting up Put Method by Id

        #region Setting up Delete Method by Id
        /// <summary>
        /// Delete author by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        [Authorize(Roles = "Customer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Author Delete Attempted = id:{id}");
                if (id < 1 )
                {
                    _logger.logWarn($"{location}:Empty request is submitted = id :{id} ");
                    return BadRequest();
                }
                var author = await _authorRepository.FindById(id);
                if (author == null)
                {
                    return NotFound();
                }

                var isSuccess = await _authorRepository.Delete(author);

                if (!isSuccess)
                {
                    return InternalError($"{location}:Author Deletetion Failed");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");

            }

        }
        #endregion Setting up Delete Method by Id

        #region Funtion For Internal Error
        private ObjectResult InternalError(string message)
        {
            _logger.logError(message);
            return StatusCode(500, "Something went worng.Please contact to Admin.");

        }

        #endregion Funtion For Internal Error

        #region Function for Contoller action name 
        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }
        #endregion Function for Contoller action name
    }
}
