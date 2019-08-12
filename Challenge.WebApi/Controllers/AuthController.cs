using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Challenge.Domain.Entities;
using Challenge.Domain.IServices;
using Challenge.Domain.Models;
using Challenge.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Challenge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IAuthService authService, IUserService userService)
        {
            _configuration = configuration;
            _authService = authService;
            _userService = userService;
        }

        [AllowAnonymous]
        [ValidateActionParameters]
        [HttpPost]
        [Route("signup")]
        public IActionResult Post([FromBody]UserViewModel userViewModel)
        {
            _userService.InsertUser(userViewModel);

            return new OkObjectResult(new
            {
                Message = "User was created successfully!",
                StatusCode = HttpStatusCode.Created
            });
        }

        [AllowAnonymous]
        [ValidateActionParameters]
        [HttpPost]
        [Route("signin")]
        public IActionResult Post([FromBody]AuthViewModel authViewModel)
        {
            var userViewModel = _authService.Authenticate(authViewModel);

            // Create the token that will be associate on User.
            var result = _authService.CreateToken(userViewModel);

            userViewModel = result.userViewModel;

            // Update LastAccess and Token.
            _userService.UpdateInfoAccess(userViewModel);

            return new OkObjectResult(new
            {
                Message = "User successfully logged in!",
                StatusCode = HttpStatusCode.OK,
                User = userViewModel,
                AccessToken = result.accessToken
            });
        }
    }
}
