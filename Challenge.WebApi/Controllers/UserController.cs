using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Domain.IServices;
using Challenge.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Challenge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        [Route("me")]
        public IActionResult Get()
        {
            if (!Request.Headers.TryGetValue("Username", out StringValues headerValue))
            {
                return Unauthorized();
            }

            var user = _userService.GetUserByEmail(headerValue);

            return new OkObjectResult(user);
        }
    }
}
