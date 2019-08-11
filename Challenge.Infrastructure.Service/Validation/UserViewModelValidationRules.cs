using Challenge.Domain.IRepositories;
using Challenge.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Service.Validation
{
    public class UserViewModelValidationRules : AbstractValidator<UserViewModel>, IUserViewModelValidationRules
    {
        private readonly IUserRepository _userRepository;

        public UserViewModelValidationRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(user => user.Firstname)
                .NotEmpty()
                .WithMessage("Firstname Missing Fields!");
            RuleFor(user => user.Lastname)
                .NotEmpty()
                .WithMessage("Lastname Missing Fields!");
            RuleFor(user => user.Email)
                .NotEmpty()
                .Must(EmailAlreadyExists)
                .WithMessage("E-mail Already Exists!");
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password Missing Fields!");
            RuleFor(user => user.Phones)
                .NotNull()
                .WithMessage("Phones Missing Fields!");
        }

        private bool EmailAlreadyExists(string email)
        {
            return (_userRepository.GetByEmail(email) == null);
        }
    }
}
