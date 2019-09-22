using AutoMapper;
using Challenge.Domain.IRepositories;
using Challenge.Domain.IServices;
using Challenge.Domain.Models;
using Challenge.Infrastructure.Service;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;

namespace Challenge.Tests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;

        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IAuthValidationService> _mockAuthValidationService;
        private readonly Mock<IUserValidationService> _mockUserValidationService;
        private readonly Mock<IConfiguration> _mockConfiguration;

        public AuthServiceTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockAuthValidationService = new Mock<IAuthValidationService>();
            _mockUserValidationService = new Mock<IUserValidationService>();
            _mockConfiguration = new Mock<IConfiguration>();

            _authService = new AuthService(
                _mockUserService.Object,
                _mockUserRepository.Object,
                _mockMapper.Object,
                _mockAuthValidationService.Object,
                _mockUserValidationService.Object,
                _mockConfiguration.Object);
        }

        public class Authenticate : AuthServiceTests
        {
            [Fact]
            public void Invalid_Password_Throws_Exception()
            {
                Assert.Throws<ValidationException>(() => _authService.Authenticate(new AuthViewModel
                {
                    Email = "xxx@gmail.com", Password = ""
                }));
            }

            //...
        }
    }
}
