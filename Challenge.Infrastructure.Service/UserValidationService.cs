using System;
using System.Collections.Generic;
using System.Text;
using Challenge.Domain.Models;
using Challenge.Infrastructure.Service.Validation;

namespace Challenge.Infrastructure.Service
{
    public class UserValidationService : IUserValidationService
    {
        private readonly IUserViewModelValidationRules _userValidationRules;

        public UserValidationService(IUserViewModelValidationRules userValidationRules)
        {
            _userValidationRules = userValidationRules;
        }

        public IUserValidationService Validate(UserViewModel userViewModel)
        {
            var _validationResult = _userValidationRules.Validate(userViewModel);

            if (!_validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(_validationResult.Errors);
            }
            return this;
        }
    }
}
