using books_api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;


        public UsersController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        /// <summary>
        /// User loging End Point
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task <IActionResult> Login ([FromBody] UserDTO userDTO)
        {
            var username = userDTO.Username;
            var password = userDTO.Password;
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

            if(result != null)
            {
                var user = await _userManager.FindByNameAsync(username);
                return Ok (user);

            }
            return Unauthorized(userDTO);
        }


    }
}
