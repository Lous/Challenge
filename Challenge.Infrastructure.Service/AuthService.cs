using AutoMapper;
using Challenge.Domain.Entities;
using Challenge.Domain.IRepositories;
using Challenge.Domain.IServices;
using Challenge.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Challenge.Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthValidationService _authValidationServices;
        private readonly IUserValidationService _userValidationService;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserRepository userRepository,
            IMapper mapper,
            IAuthValidationService authValidationService,
            IUserValidationService userValidationService,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authValidationServices = authValidationService;
            _userValidationService = userValidationService;
            _configuration = configuration;
        }

        public UserViewModel Authenticate(AuthViewModel authViewModel)
        {
            _authValidationServices.Validate(authViewModel);

            var user = _userRepository.GetByEmailAndPassword(authViewModel.Email, authViewModel.Password);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid Credentials!");

            var userViewModel = _mapper.Map<User, UserViewModel>(user);

            userViewModel.Phones = user.Phones.Select(ph => new PhoneViewModel
            {
                AreaCode = ph.AreaCode,
                CountryCode = ph.CountryCode,
                Number = ph.Number

            }).ToList();

            return userViewModel;
        }

        public (UserViewModel userViewModel, string accessToken) CreateToken(UserViewModel userViewModel)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userViewModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
            };

            #region GenereteToken

            var token = new JwtSecurityToken
            (
                issuer: _configuration["Authentication:Issuer"], audience: _configuration["Authentication:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials
                (new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["Authentication:SigningKey"])),
                    SecurityAlgorithms.HmacSha256)
            );

            #endregion

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return (userViewModel: userViewModel, accessToken: accessToken);
        }

        public bool ValidateTokenClaims(string accessToken, string username)
        {
            var subClaim = new JwtSecurityTokenHandler()
                .ReadJwtToken(accessToken
                .Split(" ")
                .ElementAtOrDefault(1))
                .Claims.Where(cl => cl.Type.Equals("sub"))
                .FirstOrDefault();

            return (subClaim != null && subClaim.Value.Equals(username));
        }
    }
}
