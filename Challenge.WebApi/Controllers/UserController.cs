using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Challenge.Domain.IServices;
using Challenge.WebApi.Filters;
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
        private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [Authorize]
        [ValidateActionParameters]
        [HttpGet]
        [Route("me")]
        public IActionResult Get()
        {
            if (!Request.Headers.TryGetValue("Authorization", out StringValues accessToken))
            {
                return new OkObjectResult(new
                {
                    Message = "Missing AccessToken!",
                    StatusCode = HttpStatusCode.Unauthorized
                });
            }

            if (!Request.Headers.TryGetValue("Username", out StringValues username))
            {
                return new OkObjectResult(new
                {
                    Message = "Missing Username HeaderParameter!",
                    StatusCode = HttpStatusCode.Unauthorized
                });
            }

            if (!_authService.ValidateTokenClaims(accessToken, username))
            {
                return new OkObjectResult(new
                {
                    Message = "Invalid Token By Username!",
                    StatusCode = HttpStatusCode.Forbidden
                });
            }

            return new OkObjectResult(_userService.GetUserInfo(username));
        }
    }
}
