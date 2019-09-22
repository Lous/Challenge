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
            var result = _userService.InsertUser(userViewModel);

            return new ObjectResult(result) { StatusCode = (int)result.StatusCode };
        }

        [AllowAnonymous]
        [ValidateActionParameters]
        [HttpPost]
        [Route("signin")]
        public IActionResult Post([FromBody]AuthViewModel authViewModel)
        {
            var result = _authService.Authenticate(authViewModel);

            return new ObjectResult(result) { StatusCode = (int)result.StatusCode };
        }
    }
}
