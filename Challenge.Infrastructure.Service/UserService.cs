using AutoMapper;
using Challenge.Domain.Entities;
using Challenge.Domain.IRepositories;
using Challenge.Domain.IServices;
using Challenge.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserValidationService _userValidationService;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IUserValidationService userValidationService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userValidationService = userValidationService;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public User GetUserById(int id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public void InsertUser(UserViewModel userViewModel)
        {
            if (userViewModel == null)
                throw new ArgumentException("UserViewModel Is Null!");

            _userValidationService.Validate(userViewModel);

            var _user = _mapper
                .Map<UserViewModel, User>(userViewModel);

            _user.Phones = userViewModel.Phones.Select(ph => new Phone
            {
                AreaCode = ph.AreaCode,
                CountryCode = ph.CountryCode,
                Number = ph.Number

            }).ToList();

            _userRepository.Insert(_user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.Get(id);

            if (user == null)
                throw new ArgumentNullException();
            _userRepository.Delete(user);

        }

        public void UpdateInfoAccess(UserViewModel userViewModel)
        {
            var user = _userRepository.GetByEmail(userViewModel.Email);

            user.LastAccess = DateTime.UtcNow;

            _userRepository.Update(user);
        }

        public UserInfoViewModel GetUserInfo(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ValidationException("Missing Fields!");

            // Email = Id in this case.
            var user = _userRepository.GetByEmail(email);

            if (user == null)
                throw new ValidationException("User Not Found!");

            var userInfoViewModel = _mapper.Map<User, UserInfoViewModel>(user);

            userInfoViewModel.Phones = user.Phones.Select(ph => new PhoneViewModel
            {
                AreaCode = ph.AreaCode,
                CountryCode = ph.CountryCode,
                Number = ph.Number

            }).ToList();

            return userInfoViewModel;
        }
    }
}
