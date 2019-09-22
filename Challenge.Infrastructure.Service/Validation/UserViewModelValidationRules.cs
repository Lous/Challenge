using Challenge.Domain.IRepositories;
using Challenge.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
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
                .WithMessage("Missing Fields!");

            RuleFor(user => user.Lastname)
                .NotEmpty()
                .WithMessage("Missing Fields!");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Missing Fields!")
                .Must(EmailAlreadyExists)
                .WithMessage("Already Exists!")
                .EmailAddress()
                .WithMessage("Invalid!");

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Missing Fields!");

            RuleFor(user => user.Phones)
                .NotNull()
                .WithMessage("Missing Fields!");
        }

        public override ValidationResult Validate(ValidationContext<UserViewModel> context)
        {
            if (context.InstanceToValidate == null)
            {
                return new ValidationResult(new[] { new ValidationFailure("User", "User Cannot Be Null!") });
            }
            return base.Validate(context);
        }

        private bool EmailAlreadyExists(string email)
        {
            return (_userRepository.GetByEmail(email) == null);
        }
    }
}
