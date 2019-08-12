using System;
using System.Collections.Generic;
using System.Text;
using Challenge.Domain.Models;
using Challenge.Infrastructure.Service.Validation;

namespace Challenge.Infrastructure.Service
{
    public class AuthValidationService : IAuthValidationService
    {
        private readonly IAuthViewModelValidationRules _authViewModelValidationRules;

        public AuthValidationService(IAuthViewModelValidationRules authViewModelValidationRules)
        {
            _authViewModelValidationRules = authViewModelValidationRules;
        }

        public IAuthValidationService Validate(AuthViewModel authViewModel)
        {
            var validationResult = _authViewModelValidationRules.Validate(authViewModel);

            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }
            return this;
        }
    }
}
