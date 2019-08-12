using Challenge.Domain.IRepositories;
using Challenge.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Service.Validation
{
    public class AuthViewModelValidationRules : AbstractValidator<AuthViewModel>, IAuthViewModelValidationRules
    {
        public AuthViewModelValidationRules()
        {
            RuleFor(auth => auth.Email)
                .NotEmpty()
                .WithMessage("Missing Fields!");

            RuleFor(auth => auth.Password)
                .NotEmpty()
                .WithMessage("Missing Fields!");
        }
    }
}
