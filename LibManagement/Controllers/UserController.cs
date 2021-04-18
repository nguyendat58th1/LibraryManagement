using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagement.Model;
using LibManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace LibManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        LibraryDBContext _context;
        public UserController(IUserService userService, LibraryDBContext context)
        {
            _userService = userService;
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<User> Get(int id)
        {
            return _userService.GetById(id);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(User user)
        {
            if (_userService.Create(user))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, User user)
        {
            if (_userService.Update(user))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (_userService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("login")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Login(User user)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            var result = _context.Users.Count(x => x.Username == user.Username && x.Password == user.Password);
            if (result > 0)
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,_context.Users.Where(x=>x.Username ==user.Username && x.Password == user.Password).Single().Username),
                    new Claim(ClaimTypes.Role,_context.Users.Where(x=>x.Username ==user.Username && x.Password == user.Password).Single().Role.ToString())

                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return Ok();
            }
            return BadRequest();

        }
        [HttpPost("logout")]
        [Authorize(Roles = "Admin,User")]
        public async System.Threading.Tasks.Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}