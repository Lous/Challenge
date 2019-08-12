using AutoMapper;
using Challenge.Domain.IRepositories;
using Challenge.Infrastructure.Service;
using Moq;
using System;
using Xunit;

namespace Challenge.Tests
{
    public class UserServiceTests
    {
        private readonly UserService _userService;

        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IUserValidationService> _mockUserValidationService;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockUserValidationService = new Mock<IUserValidationService>();

            _userService = new UserService(
                _mockUserRepository.Object,
                _mockMapper.Object,
                _mockUserValidationService.Object);
        }

        public class SignUp : UserServiceTests
        {
            [Fact]
            public void InvalidObject_Throws_Exception()
            {
                Assert.Throws<ArgumentException>(() => _userService.InsertUser(null));
            }

            //...
        }
    }
}
