using Challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Service
{
    public interface IAuthValidationService
    {
        IAuthValidationService Validate(AuthViewModel authViewModel);
    }
}
