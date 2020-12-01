
using books_api.Contracts;
using books_api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace books_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoggerService _logger;
        private readonly IConfiguration _config;

        public UsersController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration config, ILoggerService logger
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _logger = logger;
        }

        #region Setting Up Post Method 
        /// <summary>
        /// User loging End Point
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task <IActionResult> Login ([FromBody] UserDTO userDTO)
        {
            var location = GetControllerActionNames();
            var username = userDTO.Username;
            var password = userDTO.Password;
            _logger.logInfo($"{location}:Login Attempt from user {username}");
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            try
            {
                if (result.Succeeded)
                {
                    _logger.logInfo($"{location}:{username} :Succesfully Authenticated ");
                    var user = await _userManager.FindByNameAsync(username);
                    var tokenString = await GenerateJSONWebToken(user);
                    return Ok(new { toke = tokenString});

                }
                _logger.logInfo($"{location}:{username} :Authentication Failed ");
                return Unauthorized(userDTO);
            }
            catch (Exception e)
            {
               
                return  InternalError($"{location}:{e.Message} - {e.InnerException}");

            }
        }

        #endregion Setting Up Post Method 

        private async Task<string> GenerateJSONWebToken(IdentityUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var Credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier ,user.Id)
            };
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimsIdentity.DefaultNameClaimType, r)));
            var token = new JwtSecurityToken(_config["Jwt:Issuser"]
                , _config["Jwt:Issuser"],
                claims,
                null,
                expires: DateTime.Now.AddMinutes(5),
               signingCredentials: Credentials );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
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
