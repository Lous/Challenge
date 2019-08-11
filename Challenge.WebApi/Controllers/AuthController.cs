using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Challenge.Domain.Entities;
using Challenge.Domain.IServices;
using Challenge.Domain.Models;
using Challenge.WebApi.Filters;
using Challenge.WebApi.Models.Request;
using Challenge.WebApi.Models.Response;
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
                Message = "User was created successfully!", StatusCode = HttpStatusCode.OK
            });
        }

        [AllowAnonymous]
        [ValidateActionParameters]
        [HttpPost]
        [Route("signin")]
        public IActionResult Post([FromBody]SignInRequest signInRequest)
        {
            if (signInRequest == null)
                return new UnauthorizedResult();

            var currentUser = _authService.Authenticate(signInRequest.Email, signInRequest.Password);

            if (currentUser == null)
                return new UnauthorizedResult();

            // Create the token that will be associate on currentUser.
            var accessToken = _authService.CreateToken(currentUser);

            return new OkObjectResult(new { Message = "Success!", Token = accessToken, StatusCode = HttpStatusCode.OK });
        }
    }
}
