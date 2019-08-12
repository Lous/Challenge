using Challenge.Domain.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Service.Validation
{
    public interface IAuthViewModelValidationRules
    {
        ValidationResult Validate(AuthViewModel authViewModel);
    }
}
