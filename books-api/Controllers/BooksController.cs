using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using books_api.Contracts;
using books_api.Data;
using books_api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace books_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class BooksController : Controller
    {

        private readonly IBookRepository _bookRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private object bookDTO;

        public BooksController(IBookRepository bookRepository, ILoggerService logger, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _mapper = mapper;
        }

        #region Setting Up Get Method For Books 
        /// <summary>
        /// Get all Books
        /// </summary>
        /// <returns>List of Authors</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBooks()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Attempted call");
                var books = await _bookRepository.FindAll();
                var response = _mapper.Map<List<BookDTO>>(books);
                _logger.logInfo("Successfully got all Books");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");
            }

        }

        #endregion Setting Up Get Method For Books 

        #region Setting Up Get Method By Id For Books 
        /// <summary>
        /// Get Book By id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> List of Books </returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBook(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Attempted call for id:{id}");
                var book = await _bookRepository.FindById(id);
                if (book == null)
                {
                    _logger.logWarn($"Attempted failed with id:{id} was not found");
                    return NotFound();
                }
                var response = _mapper.Map<List<AuthorDTO>>(book);
                _logger.logInfo($"Successfully got book with id :{id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");

            }

        }

        #endregion Setting Up Get Method By Id For Books

        #region Setting Up Post Method for Book
      /// <summary>
      /// Post Method for Book
      /// </summary>
      /// <param name="bookDTO"></param>
      /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] BookCreateDTO bookDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Book Submission Attempted");
                if (bookDTO == null)
                {
                    _logger.logWarn($"{location}:Empty request is submitted ");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    _logger.logWarn($"{location}:Book data was incompete");
                    return BadRequest(ModelState);

                }

                var book = _mapper.Map<Book>(bookDTO);

                var isSuccess = await _bookRepository.Create(book);
                if (!isSuccess)
                {
                    return InternalError($"{location}:Book creation Failed");
                }
                return Created("create", new { book });
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");

            }

        }

        #endregion Setting Up Post Method for Book

        #region Setting Up Put Method by Id for Book
        /// <summary>
        /// Put Method by Id for Book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDTO bookDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Book Update Attempted = id:{id}");
                if (id < 1 || bookDTO == null || id != bookDTO.Id)
                {
                    _logger.logWarn($"{location}:Empty request is submitted = id :{id} ");
                    return BadRequest();
                }

                var isExists = await _bookRepository.IsExists(id);
                if (!isExists)
                {
                    _logger.logWarn($"{location}:Attempted Update Book with id:{id} was not found");
                    return NotFound();
                }

                var book = _mapper.Map<Book>(bookDTO);

                var isSuccess = await _bookRepository.Update(book);

                if (!isSuccess)
                {
                    return InternalError($"{location}:Book Updation Failed with id:{id}");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");

            }

        }
        #endregion Setting Up Put Method by Id for Book

        #region Setting Up Delete Method by Id for Book
        /// <summary>
        /// Delete Method by Id for Book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.logInfo($"{location}:Book Delete Attempted = id:{id}");
                if (id < 1)
                {
                    _logger.logWarn($"{location}:Empty request is submitted = id :{id} ");
                    return BadRequest();
                }
                var book = await _bookRepository.FindById(id);
                if (book == null)
                {
                    return NotFound();
                }

                var isSuccess = await _bookRepository.Delete(book);

                if (!isSuccess)
                {
                    return InternalError($"{location}:Book Deletetion Failed");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}:{e.Message} - {e.InnerException}");

            }

        }
        #endregion Setting Up Delete Method by Id for Book

        #region Funtion For Internal Error
        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }
        #endregion Funtion For Internal Error

        #region Function for Contoller action name
        private ObjectResult InternalError(string message)
        {
            _logger.logError(message);
            return StatusCode(500, "Something went worng.Please contact to Admin.");

        }
        #endregion Function for Contoller action name

    }
}
